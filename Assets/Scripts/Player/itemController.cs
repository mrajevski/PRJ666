using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour{

	public int capacity, bagID, size;
	/* 0 - starter backpack, 16 slots // 1 - small backpack, 24 slots // 2 - large backpack, 32 slots */
	public List<itemObject> inventory = new List<itemObject>();
	public List<itemObject> equipment = new List<itemObject>();
	public itemObject starterG1, starterG2, starterHealth, empty; 

	// Use this for initialization
	void Start () {
		capacity = 16;
		bagID = 0;
		size = 0;
		for (int i = 0; i < 32; i++) {
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
		if (size < capacity) {
			inventory[size] = i;
			size++;
			return true;
		}
		return false;
	}

	public void removeItem(int i) {
		inventory[i] = new itemObject();
		for (int I = i; inventory[I].itemID != -1; I++) {
			inventory [I - 1] = inventory [I];
		}
		size--;
	}

	public void i2i(int i1, int i2) {
		itemObject tmp = inventory [i1];
		inventory [i1] = inventory [i2];
		inventory [i2] = tmp;
	}

	public void e2i(int e, int i) {
		itemObject tmp = inventory [i];
		inventory [i] = equipment [e];
		equipment [e] = tmp;
	}

	public void i2e(int i, int e) { 
		itemObject tmp = inventory [i];
		inventory [i] = equipment [e];
		equipment [e] = tmp;
	}

	public void e2e(int e1, int e2) {
		itemObject tmp = inventory [e1];
		inventory [e1] = inventory [e2];
		inventory [e2] = tmp;
	}
}
