using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private Rigidbody rb;
    private PlayerController player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Skill"))
        {
            Debug.Log("Player got hit by Skill!");
            player.health -= other.gameObject.GetComponent<Fireball>().damage;
        }
    }
}
