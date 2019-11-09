using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashBox : MonoBehaviour
{
    public float waitTime;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();

        anim.SetBool("isFalling", false);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;

        if (waitTime >= 0f)
        {
            anim.SetBool("isFalling", false);
        }

        if (waitTime >= 5f)
        {
            anim.SetBool("isFalling", true);
        }

        if (waitTime >= 6.5f)
        {
            anim.SetBool("isFalling", false);
            waitTime = 0f;
        }
    }
}
