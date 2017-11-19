using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {

    public bool chargingMana;

    private PlayerController player;

    public Transform skillContainer;

    [System.Serializable]
    public class Skills
    {
        public GameObject skillPrefab;
        public float castTime;
        public float manaCost;
        public float cooldown;
    }

    public Skills fireball;

    public float manaChargeRate;
    private float manaChargeInterval = 0.5f;
    public float manaChargeTimer;

    public float castDuration;
    public float cooldownDuration;
    public bool skillsOnCooldown = false;

	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        ManaCharge();
        if (skillsOnCooldown)
        {
            castDuration = castDuration + Time.deltaTime;
            cooldownDuration = cooldownDuration + Time.deltaTime;
            if (castDuration >= fireball.castTime)
            {
                player.mana -= fireball.manaCost;
                GameObject.Instantiate(fireball.skillPrefab, player.position, Quaternion.Euler(0, 0, 0), skillContainer);
                castDuration = 0;
            }
            if (cooldownDuration >= fireball.cooldown)
            {
                skillsOnCooldown = false;
                cooldownDuration = 0;
                castDuration = 0;
            }
        }
	}

    public void SpellCast(GameObject Skill, float castTime, float manaCost, float cooldown)
    {
        skillsOnCooldown = true;
        
        
    }

    private void ManaCharge()
    {
        if (chargingMana)
        {
            manaChargeTimer += Time.deltaTime;
            if (manaChargeTimer >= manaChargeInterval)
            {
                player.mana += manaChargeRate;
                manaChargeTimer = 0;
            }
        }
    }
}
