using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour {

	public int ammo45;  // ID - 0
	public int ammo9mm; // ID - 1
	public int ammo556; // ID - 2
	public int ammo762; // ID - 3
	public int ammo12g; // ID - 4

	public void shot(int ammoID) {
		switch (ammoID) {
		case 0:
			ammo45--;
			break;
		case 1:
			ammo9mm--;
			break;
		case 2:
			ammo556--;
			break;
		case 3:
			ammo762--;
			break;
		case 4:
			ammo12g--;
			break;
		}
	}

	public void addAmmo(int amount, int ammoID) {
		switch (ammoID) {
		case 0:
			ammo45 += amount;
			break;
		case 1:
			ammo9mm += amount;
			break;
		case 2:
			ammo556 += amount;
			break;
		case 3:
			ammo762 += amount;
			break;
		case 4:
			ammo12g += amount;
			break;
		}
	}

	public void removeAmmo(int amount, int ammoID) {
		switch (ammoID) {
		case 0:
			ammo45 -= amount;
			break;
		case 1:
			ammo9mm -= amount;
			break;
		case 2:
			ammo556 -= amount;
			break;
		case 3:
			ammo762 -= amount;
			break;
		case 4:
			ammo12g -= amount;
			break;
		}
	}
}
