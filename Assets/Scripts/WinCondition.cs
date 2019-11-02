using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public Text winText;
    //public GameObject ball;

    private float finalTimer;
    public Text finalTimerText;

    public LifeSystem lifeSystem;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;

        finalTimerText.enabled = false;

        //lifeSystem = GetComponent<LifeSystem>();

        if(lifeSystem == null && GetComponent<LifeSystem>() != null)
        {
            lifeSystem = GetComponent<LifeSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        finalTimer = lifeSystem.timer;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            winText.enabled = true;
            finalTimerText.enabled = true;
            finalTimerText.text = "Final Time: " + finalTimer.ToString("00:00.00");
            lifeSystem.timerText.enabled = false;
        }
    }
}
