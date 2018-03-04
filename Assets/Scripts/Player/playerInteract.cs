using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour {

	public int item;
	public itemController backpack;

	void OnTriggerStay(Collider c) {
		switch (c.tag) {
		case "Item":
			if (Input.GetKey (KeyCode.E)) {
				item++;
				if (backpack.addItem (c.gameObject.GetComponent<itemObject> ()))
					c.gameObject.SetActive (false);
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
