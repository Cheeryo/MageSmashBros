using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private float forwardInput;
    private Rigidbody rb;
    private Animator playerAnimator;
    public GameObject playerModel;
    public int movementType = 2;
    public float moveAcceleration = 4;
    //Type 2
    public float maxSpeed = 5;
    public float currentSpeed;
    public float acceleration = 2;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        GetInput();        
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        SetAnimator();
    }

    private void GetInput()
    {
        forwardInput = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump"))
        {
            //do Jump
        }
    }

    private void Move()
    {
        if (movementType == 1)
        {
            rb.velocity = new Vector3(forwardInput * moveAcceleration, rb.velocity.y, 0);
        }
        else if (movementType == 2)
        {
            currentSpeed = currentSpeed + forwardInput * acceleration;
            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
            else if (currentSpeed <= -maxSpeed)
            {
                currentSpeed = -maxSpeed;
            }
            rb.velocity = new Vector3(currentSpeed, rb.velocity.y, 0);
        }
        if (forwardInput == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y,0);
        }                           
    }

    private void Turn()
    {
        if (movementType == 1)
        {
            if (forwardInput > 0)
            {
                playerModel.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (forwardInput < 0)
            {
                playerModel.transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }    
        else if (movementType == 2)
        {

        }    
    }

    private void SetAnimator()
    {
        playerAnimator.SetFloat("MoveSpeed", forwardInput);
    }
}
