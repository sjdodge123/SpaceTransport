using UnityEngine;
using System.Collections;
using System;

public class ShipController : MonoBehaviour {

    public float rotationSpeed = 1;
    public float moveSpeed;
    public float dragAmount;
    public float maxVelocity;

    private Rigidbody2D myBody;
    private bool thrusting;
    

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if (!thrusting)
        {
            myBody.velocity -= dragAmount * myBody.velocity;
        }
        thrusting = false;
    }

    public void Rotate(float horizontal)
    {
        transform.Rotate(-horizontal * Vector3.forward * rotationSpeed);
    }

    public void ApplyThrust(float vertical)
    {
        if(myBody.velocity.magnitude < maxVelocity)
        {
            myBody.AddForce(transform.up * moveSpeed * vertical);
            thrusting = true;
        }
    }
}
