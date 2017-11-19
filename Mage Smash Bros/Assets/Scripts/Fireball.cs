using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float damage;
    public float manaCost;
    public Vector3 trajectory;
    public float gravity;
    public float castTime;
    public float cooldown;
    public float timeUntilDestroy;
    private float checkTimer;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(trajectory, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeCheck();
        
    }

    private void FixedUpdate()
    {
        if (gravity > 0)
        {
            rb.AddForce(0, gravity, 0, ForceMode.Acceleration);
        }             
    }

    private void timeCheck()
    {
        if (timeUntilDestroy > 0)
        {
            checkTimer += Time.deltaTime;
            if (checkTimer >= timeUntilDestroy)
            {
                checkTimer = 0;
                Destroy(gameObject);
            }
        }
    }
}