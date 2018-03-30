using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour {

	public int ammo9mm; // ID - 0
	public int ammo44; // ID -1
	public int ammo45;  // ID - 2
	public int ammo545; // ID - 3
	public int ammo556; // ID - 4
	public int ammo762; // ID - 5
	public int ammo308; // ID - 6
	public int ammo12g; // ID - 7

	public void shot(int ammoID) {
		switch (ammoID) {
		case 0:
			ammo9mm--;
			break;
		case 1:
			ammo44--;
			break;
		case 2:
			ammo45--;
			break;
		case 3:
			ammo545--;
			break;
		case 4:
			ammo556--;
			break;
		case 5:
			ammo762--;
			break;
		case 6:
			ammo308--;
			break;
		case 7:
			ammo12g--;
			break;
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
