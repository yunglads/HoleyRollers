using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class CheckpointSystem : MonoBehaviour
    {
        public GameObject spawnpoint;

        //public bool spawnChanged = false;

        public Ball ball;

        //public Vector3 spawnPointPos;

        // Start is called before the first frame update
        void Start()
        {
            if (ball == null && GetComponent<Ball>() != null)
            {
                ball = GetComponent<Ball>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                ball.ballPosition = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z);
                //spawnChanged = true;
                Debug.Log("Trigger entered");
            }
        }
    }
}

