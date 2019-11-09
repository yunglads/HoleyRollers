using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public Text winText;
    public float seconds;
    //public float timer;
    public Text timerText;
    public int minutes;
    //public GameObject ball;

    public Text finalTimerText;

    public LifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0f;
        minutes = 0;

        winText.enabled = false;
        timerText.enabled = true;
        finalTimerText.enabled = false;

        //lifeSystem = GetComponent<LifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.fixedDeltaTime;

        //timer = timerText;

        timerText.text = "Time: " + minutes.ToString("00:") + seconds.ToString("00.00");

        if (seconds >= 59.5f)
        {
            minutes++;
            seconds = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            winText.enabled = true;
            timerText.enabled = false;
            finalTimerText.enabled = true;
            finalTimerText.text = "Final Time: " + minutes.ToString("00:") + seconds.ToString("00.00");
        }
    }
}
