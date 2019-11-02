using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float move;
    float startX;

    bool moveRight = true;

    Rigidbody rb;

    //Collider playerCol = null;

    float oldX;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        rb = GetComponent<Rigidbody>();
        oldX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0f);

            if (transform.position.x > (startX + move))
            {
                moveRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0f);

            if (transform.position.x < (startX - move))
            {
                moveRight = true;
            }
        }

        /*if (playerCol != null)
        {
            if (!playerCol.enabled)
                playerCol = null;
        }*/

    }

    /*void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (playerCol != null && collision.collider == playerCol)
            {
                float deltaX = transform.position.x - oldX;
                playerCol.transform.position = new Vector3(playerCol.transform.position.x + deltaX, playerCol.transform.position.y, playerCol.transform.position.z);
            }
            playerCol = collision.collider;
            oldX = transform.position.x;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider == playerCol)
        {
            playerCol = null;
        }
    }*/

    void OnDrawGizmos()
    {
        //Draw wire cube of patrol area
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3((move * 2) + transform.localScale.x, transform.localScale.y, 0));
    }
}
