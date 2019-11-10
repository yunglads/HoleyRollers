using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Ball;

public class StartTimer : MonoBehaviour
{
    public Text startTimer;
    public Text go;
    public float timer;

    public BallUserControl ball;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3.5f;

        if (ball == null && GetComponent<BallUserControl>() != null)
        {
            ball = GetComponent<BallUserControl>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.fixedDeltaTime % 60;

        startTimer.text = timer.ToString("0");

        if (timer > 0f)
        {
            startTimer.enabled = true;
            ball.enabled = false;
            go.enabled = false;
        }
        else if (timer <= -0.5f)
        {
            startTimer.enabled = false;
            ball.enabled = true;
            go.enabled = true;
        }

        if (timer <= -2f)
        {
            go.enabled = false;
        }

        if (timer <= -3f)
        {
            Destroy(gameObject);
        }
    }
}
