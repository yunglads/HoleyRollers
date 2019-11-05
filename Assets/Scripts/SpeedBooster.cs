using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class SpeedBooster : MonoBehaviour
    {
        public GameObject playerBall;
        public float boostedSpeed;

        private float waitTime;
        private bool inBooster = false;

        public Ball ball;

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
            if (inBooster)
            {
                waitTime += Time.deltaTime;
            }

            if (inBooster && waitTime >= 0f)
            {
                playerBall.GetComponent<Rigidbody>().AddForce(transform.forward * boostedSpeed);
            }

            if (inBooster && waitTime >= 2f)
            {
                playerBall.GetComponent<Rigidbody>().AddForce(-transform.forward * boostedSpeed);
                inBooster = false;
                waitTime = 0f;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                inBooster = true;
                //ball.m_MovePower = boostedSpeed;
            }
        }
    }
}
