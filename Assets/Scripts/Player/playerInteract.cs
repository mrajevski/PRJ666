using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour {

	public int items;
	public itemController backpack;

	void OnTriggerStay(Collider c) {
		switch (c.tag) {
		case "Item":
			if (Input.GetKey (KeyCode.E)) {
				if (backpack.addItem (c.gameObject.GetComponent<itemObject> ())) {
					c.gameObject.SetActive (false);
					items++;
				}
			}
			break;
		case "Door":
			break;
		case "NPC":
			break;
		case "Car":
			break;
		}
	}
}
