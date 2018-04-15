using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour {

	public List<int> ammo; // 9mm - 0, .44 - 1, .45 - 2, 5.45 - 3, 5.56 - 4, 7.62 - 5, .308 - 6, 12g - 7

	void Start() {
		for (int i = 0; i < 8; i++) {
			ammo.Add (0);
		}
		ammo [0] = 50;
		ammo [3] = 60;
	}

	public bool shot(int ID) {
		if (ammo [ID] > 0)
			ammo [ID]--;
		else
			return false;
		return true;
	}

	public void addAmmo(int amount, int ID) {
		ammo [ID] += amount;
	}

	public void removeAmmo(int amount, int ID) {
		ammo [ID] = ((ammo [ID] - amount) < 0) ? 0 : ammo [ID] - amount;
	}
}
