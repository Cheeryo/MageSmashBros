using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    private Rigidbody rb;
    private PlayerInputs inputs;
    private Animator playerAnimator;
    public GameObject playerModel;
    public int movementType = 2;

    public Vector3 position;

    public float moveAcceleration = 4;
    private float moveAccelerationFactor = 1;
    //Type 2
    public float maxSpeed = 5;
    public float currentSpeed;
    public float acceleration = 2;
    //Jump
    [Header("Attributes")]
    [Range(0, 100)] public float health;
    [Range(0, 100)] public float mana;

    [Header("States")]
    public bool isGrounded;
    public bool isMidAir;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        inputs = GetComponent<PlayerInputs>();
        playerAnimator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        position = this.transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        Jump();
        SetAnimator();
    }

    private void SetAnimator()
    {
        playerAnimator.SetFloat("MoveSpeed", inputs.horizontalInput);
    }

    private void GroundCheck()
    {
        RaycastHit groundCheck;
        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        if (Physics.Raycast(transform.position, Vector3.down, out groundCheck, 0.1f))
        {
            if (groundCheck.collider.CompareTag("Level"))
            {
                isGrounded = true;
                isMidAir = false;
            }
            else
            {
                isGrounded = false;
                isMidAir = true;
            }
        }
        else
        {
            isGrounded = false;
            isMidAir = true;
        }
    }

    private void Move()
    {
        if (movementType == 1)
        {
            if (isGrounded && !isMidAir)
            {
                moveAccelerationFactor = 1;
            }
            else if (isMidAir && !isGrounded)
            {
                moveAccelerationFactor = 0.6f;
            }
            rb.velocity = new Vector3(inputs.horizontalInput * moveAcceleration * moveAccelerationFactor, rb.velocity.y, 0);
        }
        else if (movementType == 2)
        {
            currentSpeed = currentSpeed + inputs.horizontalInput * acceleration;
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
        if (inputs.horizontalInput == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y,0);
        }                           
    }

    private void Turn()
    {
        if (movementType == 1)
        {
            if (inputs.horizontalInput > 0)
            {
                playerModel.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (inputs.horizontalInput < 0)
            {
                playerModel.transform.eulerAngles = new Vector3(0, -90, 0);
            }
        }    
        else if (movementType == 2)
        {

        }    
    }
    
    private void Jump()
    {
        if (inputs.doJump && isGrounded)
        {
            rb.AddForce(0, 3.5f, 0, ForceMode.VelocityChange);
            inputs.doJump = false;
        }
    }    
}
