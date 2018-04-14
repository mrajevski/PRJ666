using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour {

	public Canvas ui;
	public Text ammo9mm, ammo44, ammo45, ammo545, ammo556, ammo762, ammo308, ammo12g;
	public GameObject backpack;
	public itemObject selected, empty;
	public float mX = 0, mY = 0;
	int UIMask;
	itemController inventory;
	ammoController ammo;
	bool openUI = false;

	// Use this for initialization
	void Start () {
		inventory = backpack.GetComponent<itemController> ();
		ammo = backpack.GetComponent<ammoController> ();
		ui.enabled = false;/*
		for (int i = 0; i < 32; i++) {
			GameObject I = GameObject.Find ("Inventory/Slot " + i.ToString() + "/Item");
			GameObject T = GameObject.Find ("Inventory/Slot " + i.ToString() + "/Item/Text");
		}*/
	}

	// Update is called once per frame
	void Update () {
		mX = Input.mousePosition.x;
		mY = Input.mousePosition.y;
		if (Input.GetKeyDown(KeyCode.Tab)) {
			openUI = !openUI;
			ui.enabled = openUI;
		}
		if (openUI) {
			updateAmmo ();
			updateInventory ();
			updateEquipment ();
		}
	}

	void updateAmmo() {
		ammo9mm.text = ammo.ammo9mm.ToString ();
		ammo44.text = ammo.ammo44.ToString ();
		ammo45.text = ammo.ammo45.ToString ();
		ammo545.text = ammo.ammo545.ToString ();
		ammo556.text = ammo.ammo556.ToString ();
		ammo762.text = ammo.ammo762.ToString ();
		ammo308.text = ammo.ammo308.ToString ();
		ammo12g.text = ammo.ammo12g.ToString ();
	}

	void updateInventory() {
		for (int j = 0; j < inventory.capacity; j++) {
			GameObject I = GameObject.Find ("Inventory/Slot " + j.ToString() + "/Item");
			I.GetComponent<Image>().sprite = inventory.inventory [j].image;
			GameObject T = GameObject.Find ("Inventory/Slot " + j.ToString() + "/Item/Text");
			Text t = T.GetComponent<Text> ();
			t.text = inventory.inventory [j].name;
		}
		if (inventory.bagID >= 1) {
			GameObject.Find ("Inventory/1").SetActive(true);
			if (inventory.bagID == 2) 
				GameObject.Find ("Inventory/1/2").SetActive(true);				
		}
	}

	void updateEquipment() {
		for (int j = 0; j < 9; j++) {
			GameObject I = GameObject.Find ("Hotbar/Slot " + j.ToString () + "/Item");
			I.GetComponent<Image> ().sprite = inventory.equipment[j].image;
		}

	}

}



/*
			if ((x >= -168f && x <= 168f) && (y >= -50f && y <= 45f)) {
				float X = -142.2f, Y = 30.1f;
				for (int i = 0; i < 8; i++) {
					if ((x >= (X - 25.71f) && x <= (X + 25.71f)) && (y >= 15f && y <= 45.5f)) {
						selected = inventory.inventory[i];
						itemSelected = true;
						break;
					}
					X += 31.42f;
				}
				if (!itemSelected) {
					X = 0.0f;
					Y = -6.8f;
					for (int i = 8; i < 16; i++) {
						if ((x >= (X - 25.71) && x <= (X + 25.71)) && (y >= -21.8f && y <= 8.2f)) {
							selected = inventory.inventory[i];
							itemSelected = true;
							break;
						}
						X += 31.42f;
					}
					// If backback is upgraded
					if (!itemSelected && inventory.bagID >= 1) { 
						X = 0.0f;
						Y = -6.8f;
						for (int i = 8; i < 16; i++) {
							if ((x >= (X - 25.71f) && x <= (X + 25.71f)) && (y >= -21.8f && y <= -21.8f)) {
								selected = inventory.inventory[i];
								itemSelected = true;
								break;
							}
							X += 31.42f;
						}
						if (!itemSelected && inventory.bagID == 2) { 
							X = 0.0f;
							Y = -6.8f;
							for (int i = 8; i < 16; i++) {
								if ((x >= (X - 25.71f) && x <= (X + 25.71f)) && (y >= -50f && y <= 8.2f)) {
									selected = inventory.inventory[i];
									itemSelected = true;
									break;
								}
								X += 31.42f;
							}
						}
					}
				}
			
			}*/