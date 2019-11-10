using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Ball;

public class WinCondition : MonoBehaviour
{
    public Text winText;
    public float seconds;
    public Text timerText;
    public int minutes;
    private bool raceOver;
    public Text finalTimerText;

    public LifeSystem lifeSystem;
    public StartTimer startTimer;
    public BallUserControl ball;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0f;
        minutes = 0;

        winText.enabled = false;
        timerText.enabled = false;
        finalTimerText.enabled = false;

        if (startTimer == null && GetComponent<StartTimer>() != null)
        {
            startTimer = GetComponent<StartTimer>();
        }

        if (ball == null && GetComponent<BallUserControl>() != null)
        {
            ball = GetComponent<BallUserControl>();
        }

        //lifeSystem = GetComponent<LifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer.timer <= -.5f && !raceOver)
        {
            seconds += Time.fixedDeltaTime;
            timerText.enabled = true;
            timerText.text = "Time: " + minutes.ToString("00:") + seconds.ToString("00.00");

            if (seconds >= 59.5f)
            {
                minutes++;
                seconds = 0f;
            }
        }
        else if (raceOver)
        {
            timerText.enabled = false;
            ball.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            winText.enabled = true;
            timerText.enabled = false;
            ball.enabled = false;
            raceOver = true;
            finalTimerText.enabled = true;
            finalTimerText.text = "Final Time: " + minutes.ToString("00:") + seconds.ToString("00.00");
        }
    }
}
