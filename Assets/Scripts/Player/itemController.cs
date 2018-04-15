using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour{

	public int capacity, bagID, size, armorLVL = -1;
	/* 0 - starter backpack, 16 slots // 1 - small backpack, 24 slots // 2 - large backpack, 32 slots */
	public List<itemObject> inventory = new List<itemObject>();
	public List<itemObject> equipment = new List<itemObject>();
	public itemObject starterG1, starterG2, starterHealth, empty;
	public ammoController ammo;
	bool mask = false;

	// Use this for initialization
	void Start () {
		capacity = 16;
		bagID = 0;
		size = 1;
		for (int i = 0; i < 33; i++) {
			inventory.Add(empty);
		}
		for (int i = 0; i < 9; i++) {
			equipment.Add(empty);
		}
		equipment [0] = starterG1;
		equipment [1] = starterG2;
		inventory [0] = starterHealth;
	}

	public bool addItem(itemObject i) {
		switch (i.itemType) {
		case 0:
			if (size < capacity) {
				inventory [size] = i;
				size++;
				return true;
			}
			return false;
		case 1:
			ammo.addAmmo (50, i.itemCode);
			return true;
		case 2:
			if (size < capacity) {
				inventory [size] = i;
				size++;
				return true;
			}
			return false;
		case 3:
			if (size < capacity) {
				inventory [size] = i;
				size++;
				return true;
			}
			return false;
		case 4:
			// armor = i.itemCode;
			return true;
		case 5:
			bagID = i.itemCode;
			return true;
		case 6:
			mask = true;
			return true;
		default:
			return false;
		}
	}

	public void removeItem(int i) {
		for (; inventory[i].itemID != -1; i++) {
			inventory [i] = inventory [i + 1];
		}
		inventory [i] = empty;
		size--;
	}

	// Switch within the inventory //
	public void i2i(int i1, int i2) {
		if (inventory[i1].itemID != -1 || inventory[i2].itemID != -1) {
			itemObject tmp = inventory [i1];
			inventory [i1] = inventory [i2];
			inventory [i2] = tmp;
		}
	}

	// Switch between inventory and equipment //
	public void swap(int i, int e) { 
		if (inventory [i].itemID == -1 && equipment [e].itemID != -1) {
			itemObject tmp = inventory [i];
			inventory [i] = equipment [e];
			equipment [e] = tmp;
			size++;
		} else if (inventory [i].itemID != -1 || equipment [e].itemID == -1) {
			if (inventory [i].itemType == 0) {
				if (e < 3) {
					itemObject tmp = inventory [i];
					inventory [i] = equipment [e];
					equipment [e] = tmp;
					size--;
				}
			} else if (inventory [i].itemType > 0) {
				if (e > 2) {
					itemObject tmp = inventory [i];
					inventory [i] = equipment [e];
					equipment [e] = tmp;
					size--;
				}
			}
		}		
	}

	// Switch within the equipment //
	public void e2e(int e1, int e2) {
		if ((e1 < 3 && e2 < 3) || (e1 > 2 && e2 > 2)) {
			itemObject tmp = equipment [e1];
			equipment [e1] = equipment [e2];
			equipment [e2] = tmp;
		}
	}
}
