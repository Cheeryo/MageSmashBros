using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {

    public float horizontalInput;
    public float verticalInput;
    public bool doJump = false;

    private PlayerSkills skills;
    private PlayerController player;

    // Use this for initialization
    void Start () {
        skills = GetComponent<PlayerSkills>();
        player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    private void GetInput()
    {
        //Move
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if ((Input.GetButton("Jump") && !skills.chargingMana) || (verticalInput > 0.7f && !skills.chargingMana))
        {
            doJump = true;
            //do Jump
        }
        if (Input.GetButton("Fire") && !skills.skillsOnCooldown)
        {
            //do Fire
            skills.skillsOnCooldown = true;
        }
        if (Input.GetButtonDown("Reload") && player.isGrounded)
        {
            //start Reloading
            skills.chargingMana = true;
        }
        if (Input.GetButtonUp("Reload"))
        {
            //stop reloading
            skills.chargingMana = false;
            skills.manaChargeTimer = 0;
        }
    }
}
