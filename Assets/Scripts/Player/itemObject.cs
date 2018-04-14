using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemObject : MonoBehaviour{

	public int itemID, itemType, itemCode;
	/* itemType: 0 - gun, 1 - ammo, 2 - gas, 3 - health, 4 - armor, 5 - backpack, 6 - gas mask */
	/* itemCode varies based on teh itemType
	// gun: 0 is the only value
	// ammo: itemCode is the ammo type
	// gas: 0 is the only value
	// health: 0 - food1, 1 - food2, 2 - pills1, 3 - bandage, 4 - pills2, 5 - medkit
	// armor: item code is the armor value
	*/
	public Sprite image;
	public string name;
	public gunObject gun;

	public itemObject() {
		itemID = -1;
		itemType = -1;
		itemCode = -1;
		image = null;
		name = "";
		gun = null;
	}

	void Start() {
		if (itemType != 0) {
			gun = null;
		}
	}
}
