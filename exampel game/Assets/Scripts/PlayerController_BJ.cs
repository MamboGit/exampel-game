using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_BJ : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody myRigidbody;

    public float jumpSpeed;

    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;

    public bool isGrounded;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            isGrounded = false;
        }
            
    }

    void OnCollisionEnter()
    {
        isGrounded = true;

    }

     void OnEnable()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        myRigidbody.AddForce(gravity, ForceMode.Acceleration);
    }
}

