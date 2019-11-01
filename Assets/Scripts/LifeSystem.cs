using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int lives;
    public Text livesText;
    public float timer;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;

        livesText.text = "Lives: " + lives;
        timerText.text = "Time: " + timer.ToString("00:00.00");
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
