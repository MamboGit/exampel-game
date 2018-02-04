using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float thrust;
    public float JumpHeight;
    public bool isGrounded;
    public float GravityStrength;

    Rigidbody rb;


    void Start () {

        rb = GetComponent<Rigidbody>();

        Vector3 gravityS = new Vector3(0, GravityStrength, 0);
        Physics.gravity = gravityS;

        isGrounded = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("d"))
        {
            gameObject.transform.position = new Vector3(transform.position.x + 6 * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.position = new Vector3(transform.position.x - 6 * Time.deltaTime, transform.position.y, transform.position.z);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey("w") && isGrounded == true)

        {
            Jump();

        }
    }

    void Jump()
    {

        rb.AddForce(new Vector3(0, JumpHeight, 0));
        isGrounded = false;
    }

    void OnCollisionEnter()
    {
        isGrounded = true;

    }








}

