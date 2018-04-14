using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunObject : MonoBehaviour {

	public float reloadTime, accuracy, rateOfFire;
	public int damage, magCapacity, gunID, ammoID, value;
	public short fireMode /* 0 - Full Auto, 1 - Single Shot, 2 - Shotgun*/;
	public AudioSource gunAudio, reloadAudio;


	public gunObject() {
		reloadTime = -1.0f;
		accuracy = -1.0f;
		rateOfFire = -1.0f;
		damage = -1;
		magCapacity = -1;
		gunID = -1;
		ammoID = -1;
		value = -1;
		fireMode = -1;
		gunAudio = null;
		reloadAudio = null;
	}

}
