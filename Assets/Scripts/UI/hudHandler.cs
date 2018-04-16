using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudHandler : MonoBehaviour {

	itemController inventory;
	playerShoot shootHandler;

	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Player/Backpack").GetComponent<itemController> ();
		shootHandler = GameObject.Find ("Player").GetComponent<playerShoot> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateEquipment ();
		updateGuns ();
		updateAmmo ();
	}

	void updateEquipment() {
		for (int j = 4; j < 10; j++) {
			GameObject I = GameObject.Find ("Equipment/Item " + j.ToString());
			I.GetComponent<Image> ().sprite = inventory.equipment [j - 1].image;
		}
	}

	void updateGuns() {
		GameObject I = GameObject.Find ("Guns/Item 3");
		I.GetComponent<Image> ().sprite = inventory.equipment [inventory.g].image;
		switch (inventory.g) {
		case 0:
			I = GameObject.Find ("Guns/Item 1");
			I.GetComponent<Image> ().sprite = inventory.equipment [1].image;
			I = GameObject.Find ("Guns/Item 2");
			I.GetComponent<Image> ().sprite = inventory.equipment [2].image;
			break;
		case 1:
			I = GameObject.Find ("Guns/Item 1");
			I.GetComponent<Image> ().sprite = inventory.equipment [0].image;
			I = GameObject.Find ("Guns/Item 2");
			I.GetComponent<Image> ().sprite = inventory.equipment [2].image;
			break;
		case 2:
			I = GameObject.Find ("Guns/Item 1");
			I.GetComponent<Image> ().sprite = inventory.equipment [0].image;
			I = GameObject.Find ("Guns/Item 2");
			I.GetComponent<Image> ().sprite = inventory.equipment [1].image;
			break;

		}
	}

	void updateAmmo() {
		GameObject T = GameObject.Find ("Guns/Ammo count");
		T.GetComponent<Text> ().text = 
			((shootHandler.chamber) ? (shootHandler.mag + 1).ToString() : shootHandler.mag.ToString()) + " / " +
			inventory.ammo.ammo[inventory.equipment [inventory.g].gun.ammoID].ToString();
	}
}
