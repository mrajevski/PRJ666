using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour {

	public int capacity, bagID, size;
	public string last;
	/* 0 - starter bag, 16 slots // 1 - small backpack, 24 slots // 2 - travel bag, 32 slots */
	public List<itemObject> inventory = new List<itemObject>();

	// Use this for initialization
	void Start () {
		capacity = 16;
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
