using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lives;
    public Text livesText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
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
