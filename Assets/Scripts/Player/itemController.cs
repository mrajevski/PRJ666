using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour {

	public int capacity, bagID, size;
	public string last;
	/* 0 - starter bag, 10 slots // 1 - small backpack, 15 slots 
	 * 2 - travel bag, 20 slots // 3 - camping bag, 25 slots
	 * 4 - military bag, 35 slots */
	List<itemObject> inventory = new List<itemObject>();

	// Use this for initialization
	void Start () {
		capacity = 10;
		bagID = 0;
		size = 0;
	}

	public bool addItem(itemObject i) {
		if (size < capacity) {
			inventory.Add (i);
			last = inventory[size].name;
			size++;

			return true;
		}
		else {
			return false;
			// remove another item //
		}
	}

	public void removeItem(int i) {
		inventory.RemoveAt (i);
		size--;
	}

}
