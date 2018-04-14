using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour {

	public int ammo9mm; // ID - 0
	public int ammo44 = 0;  // ID - 1
	public int ammo45 = 0;  // ID - 2
	public int ammo545; // ID - 3
	public int ammo556 = 0; // ID - 4
	public int ammo762 = 0; // ID - 5
	public int ammo308 = 0; // ID - 6
	public int ammo12g = 0; // ID - 7

	void Start() {
		ammo9mm = 50;
		ammo545 = 60;
	}

	public bool shot(int ammoID) {
		switch (ammoID) {
		case 0:
			if (ammo9mm > 0)
				ammo9mm--;
			else
				return false;
			return true;
		case 1:
			if (ammo44 > 0)
				ammo44--;
			else
				return false;
			return true;
		case 2:
			if (ammo45 > 0)
				ammo45--;
			else
				return false;
			return true;
		case 3:
			if (ammo545 > 0)
				ammo545--;
			else
				return false;
			return true;
		case 4:
			if (ammo556 > 0)
				ammo556--;
			else
				return false;
			return true;
		case 5:
			if (ammo762 > 0)
				ammo762--;
			else
				return false;
			return true;
		case 6:
			if (ammo308 > 0)
				ammo308--;
			else
				return false;
			return true;
		case 7:
			if (ammo12g > 0)
				ammo12g--;
			else
				return false;
			return true;
		default:
			return false;	
		}
	}

	public void addAmmo(int amount, int ammoID) {
		switch (ammoID) {
		case 0:
			ammo9mm += amount;
			break;
		case 1:
			ammo44 += amount;
			break;
		case 2:
			ammo45 += amount;
			break;
		case 3:
			ammo545 += amount;
			break;
		case 4:
			ammo556 += amount;
			break;
		case 5:
			ammo762 += amount;
			break;
		case 6:
			ammo308 += amount;
			break;
		case 7:
			ammo12g += amount;
			break;
		}
	}

	public void removeAmmo(int amount, int ammoID) {
		switch (ammoID) {
		case 0:
			ammo9mm = ((ammo9mm - amount) < 0) ? 0 : ammo9mm - amount;
			break;
		case 1:
			ammo44 = ((ammo44 - amount) < 0) ? 0 : ammo44 - amount;
			break;
		case 2:
			ammo45 = ((ammo45 - amount) < 0) ? 0 : ammo45 - amount;
			break;
		case 3:
			ammo545 = ((ammo545 - amount) < 0) ? 0 : ammo545 - amount;
			break;
		case 4:
			ammo556 = ((ammo556 - amount) < 0) ? 0 : ammo556 - amount;
			break;
		case 5:
			ammo762 = ((ammo762 - amount) < 0) ? 0 : ammo762 - amount;
			break;
		case 6:
			ammo308 = ((ammo308 - amount) < 0) ? 0 : ammo308 - amount;
			break;
		case 7:
			ammo12g = ((ammo12g - amount) < 0) ? 0 : ammo12g - amount;
			break;
		}
	}
}
