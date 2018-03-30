using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemObject : MonoBehaviour {

	public int itemID, itemType, itemCode, jim;
	/* itemType: 0 - gun, 1 - ammo, 2 - gas, 3 - health, 4 - armor */
	/* itemCode varies based on teh itemType
	// gun: 0 is the only value
	// ammo: itemCode is the ammo type
	// gas: 0 is the only value
	// health: 0 - food1, 1 - food2, 2 - pills1, 3 - bandage, 4 - pills2, 5 - medkit
	// armor: item code is the armor value
	*/
	public Sprite image;
	public string name;
	public gunObject gunInfo;

	void Start() {
		if (itemType != 0) {
			gunInfo = null;
		}
	}
}
