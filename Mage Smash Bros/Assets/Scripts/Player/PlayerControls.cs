using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private float forwardInput;
    private Rigidbody rb;
    private Animator playerAnimator;

    public float moveAcceleration = 4;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    private void FixedUpdate()
    {
        Move();
        SetAnimator();
    }

    private void GetInput()
    {
        forwardInput = Input.GetAxis("Horizontal");
        Debug.Log(forwardInput);

        if (Input.GetButton("Jump"))
        {
            Debug.Log("jump");
        }
    }

    private void Move()
    {
        rb.velocity = new Vector3(forwardInput * moveAcceleration, rb.velocity.y, 0);
    }

    private void SetAnimator()
    {
        playerAnimator.SetFloat("MoveSpeed", forwardInput);
    }
}
