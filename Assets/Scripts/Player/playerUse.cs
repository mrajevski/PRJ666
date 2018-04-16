using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUse : MonoBehaviour {

	itemController inventory;
	playerHealth health;

	// Use this for initialization
	void Start () {
		health = GameObject.Find ("Player").GetComponent<playerHealth> ();
		inventory = GameObject.Find ("Player/Backpack").GetComponent<itemController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha4))
			useItem (3);
		
		if (Input.GetKeyDown(KeyCode.Alpha5))
			useItem (4);
		
		if (Input.GetKeyDown(KeyCode.Alpha6))
			useItem (5);
		
		if (Input.GetKeyDown(KeyCode.Alpha7))
			useItem (6);
		
		if (Input.GetKeyDown(KeyCode.Alpha8))
			useItem (7);
		
		if (Input.GetKeyDown(KeyCode.Alpha9))
			useItem (8);
	}

	void useItem(int e) {
		itemObject i = inventory.equipment [e];
		if (i.itemType == 3) {
			float heal = 0.0f;

			switch (i.itemCode) {
			case 0:
				heal = 10.0f;
				break;
			case 1:
				heal = 20.0f;
				break;
			case 2:
				heal = 40.0f;
				break;
			case 3:
				heal = 60.0f;
				break;
			case 4:
				heal = 80.0f;
				break;
			case 5:
				heal = 100.0f;
				break;
			}

			if (health.health + heal >= 100.0f)
				health.health = 100.0f;
			else
				health.health += heal;
			inventory.equipment [e] = inventory.empty;
		}
	}
}
