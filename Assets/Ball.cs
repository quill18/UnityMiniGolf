using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.5f; // Default is 0.005

    }

    Rigidbody rb;

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
