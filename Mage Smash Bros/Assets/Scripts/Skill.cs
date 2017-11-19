using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour {

    enum SkillType
    {
        Attack, Defense, Movement
    }

    public string Name;
    [SerializeField] SkillType type;
    public Image icon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
