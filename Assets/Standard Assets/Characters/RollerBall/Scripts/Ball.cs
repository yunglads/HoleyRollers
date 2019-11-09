using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] public float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        [SerializeField] private float m_wallJumpPower = 3f;

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;

        private float waitTime;
        public Vector3 ballPosition;
        public bool playerDead = false;
        public bool canLeap;
        //public bool isJumping = false;

        public int leapCount;
        public Text leapText;

        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;

            canLeap = true;

            ballPosition = new Vector3(0, 1, 0);
        }


        void Update()
        {
            //ballPosition = new Vector3(0f, 1f, transform.position.z - 20f);

            leapText.text = "Leaps: " + leapCount;

            if (playerDead == true)
            {
                waitTime += Time.deltaTime;
            }

            if (waitTime >= 3f)
            {
                playerDead = false;
                waitTime = 0f;
                m_Rigidbody.constraints = RigidbodyConstraints.None;
            }

            if (leapCount == 0)
            {
                waitTime += Time.deltaTime;
            }

            if (leapCount <= 0 && waitTime >= 1f)
            {
                canLeap = false;
            }
            else if (leapCount >= 1)
            {
                canLeap = true;
            }

            if (leapCount <= -1)
            {
                leapCount = 0;
            }

            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                waitTime += Time.fixedDeltaTime;
                if (waitTime >= 1f)
                {
                    isJumping = true;
                    waitTime = 0f;
                }
            }*/
        }      

        public void Move(Vector3 moveDirection, bool jump)
        {
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump && canLeap)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
                //leapCount--;
            }

            if (Physics.Raycast(transform.position, Vector3.right, k_GroundRayLength) && jump && canLeap)
            {
                m_Rigidbody.AddForce(Vector3.up * m_wallJumpPower, ForceMode.Impulse);
                m_Rigidbody.AddForce(-Vector3.right * m_wallJumpPower, ForceMode.Impulse);
                //leapCount--;
            }

            if (Physics.Raycast(transform.position, -Vector3.right, k_GroundRayLength) && jump && canLeap)
            {
                m_Rigidbody.AddForce(Vector3.up * m_wallJumpPower, ForceMode.Impulse);
                m_Rigidbody.AddForce(Vector3.right * m_wallJumpPower, ForceMode.Impulse);
                //leapCount--;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Boundary")
            {
                playerDead = true;
                leapCount++;
                transform.position = ballPosition;
                m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }

            if (other.tag == "+1 Box")
            {
                leapCount++;
                //Debug.Log("Worked!");
            }

            if (other.tag == "-1 Box")
            {
                leapCount--;
                //Debug.Log("Worked!");
            }

            if (other.tag == "Smash Box")
            {
                playerDead = true;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "World")
            {
                canLeap = true;
                //isJumping = false;
            }

            if (collision.gameObject.tag == "Ramp")
            {
                leapCount++;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "World")
            {
                leapCount--;
            }
        }
    }
}
