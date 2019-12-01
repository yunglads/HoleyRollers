using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lives;
    public Text livesText;

    public WinCondition winCondition;


    // Start is called before the first frame update
    void Start()
    {
        if (winCondition == null && GetComponent<WinCondition>() != null)
        {
            winCondition = GetComponent<WinCondition>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        winCondition = GameObject.FindObjectOfType<WinCondition>();

        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            winCondition.raceOver = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            lives--;
            Debug.Log("Live Lost! Current lives: " + lives.ToString());
        }
    }
}
