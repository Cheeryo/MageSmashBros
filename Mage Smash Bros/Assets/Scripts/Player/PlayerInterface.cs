using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour {

    public Slider healthSlider;
    public Image healtImage;
    public Slider manaSlider;
    public Image manaImage;

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        SetUI();
	}

    private void SetUI()
    {
        healthSlider.value = player.health;
        manaSlider.value = player.mana;
    }
}
