using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseTimer : MonoBehaviour
{
    public int timeDecreased;

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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winCondition.seconds -= timeDecreased;
            Destroy(gameObject);
        }
    }
}
