using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 20;
        rb.velocity *= speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
