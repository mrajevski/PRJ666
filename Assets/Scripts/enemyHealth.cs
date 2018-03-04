using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

	int health = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0) {
			this.gameObject.SetActive (false);
		}
	}

	public void takeDamage(int damage) {
		health -= damage;
	}
}
