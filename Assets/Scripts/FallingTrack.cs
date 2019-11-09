﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrack : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            Debug.Log("Using Grav");
        }
    }
}
