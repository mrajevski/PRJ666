using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

	public float reloadTime, accuracy, currAccuracy = 100.0f, rateOfFire;
	public int range = 100, damage, magCapacity, mag, ammoID, gunID;
	public Transform aim, player;
	bool chamber = true, reloading = false, aiming = false, sprinting = false;
	public ammoController ammo;
	
	float timer;
	Ray shootRay = new Ray();
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	public gunObject g1, g2, g3;
	public AudioSource gunAudio, gunAudioSingle, reloadAudio;
	float shotDisplayTime = 0.1f;
	private Transform playerAccuracy;

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		playerAccuracy = GetComponent<Transform> ();
		gunLine = GetComponent <LineRenderer> ();
		//gunAudio = GetComponent<AudioSource> ();
	}


	void Update ()
	{
		timer += Time.deltaTime;

		// Shoot //
		if(Input.GetKey(KeyCode.Mouse0) && timer >= rateOfFire && Time.timeScale != 0) {
			if (chamber && !reloading && !sprinting) {
				Shoot();
			}
		}

		// Reload //
		if (Input.GetKey(KeyCode.R) && !reloading) {
			timer = 0.0f;
			mag = (chamber) ? magCapacity : magCapacity - 1 ;
			chamber = true;
			reloading = true;
			reloadAudio.Play ();
		}

		// Reload Timer //
		if (reloading) {
			if (timer >= reloadTime)
				reloading = false;
		}

		// Rate of Fire //
		if (timer >= rateOfFire * shotDisplayTime + 0.02f) {
			disableShot();
		}

		// Aiming //
		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			currAccuracy += 5.0f;
		}
		if (Input.GetKeyUp(KeyCode.Mouse1)) {
			currAccuracy -= 5.0f;
		}

		// Accuracy Cone //
		if (currAccuracy < 100.0f) { 
			currAccuracy += 0.1f;
		}

		// Sprinting //
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			sprinting = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			sprinting = false;
		}

		// Weapon Switching //
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			//if (gunID != g1.gunID)
				switchGun(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			//if (gunID != g2.gunID)
				switchGun(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			//if (gunID != g3.gunID)
				switchGun(2);
		}
	}


	public void disableShot ()
	{
		gunLine.enabled = false;
	}


	void switchGun(int slot) {
		switch (slot) {
		case 0:
			setGun (g1.gunID, g1.ammoID, g1.rateOfFire, g1.damage, g1.magCapacity, g1.reloadTime, g1.accuracy, g1.gunAudio, g1.gunAudioSingle, g1.reloadAudio);
			break;
		case 1:
			setGun (g2.gunID, g2.ammoID, g2.rateOfFire, g2.damage, g2.magCapacity, g2.reloadTime, g2.accuracy, g2.gunAudio, g2.gunAudioSingle, g2.reloadAudio);
			break;
		case 2:
			setGun (g3.gunID, g3.ammoID, g3.rateOfFire, g3.damage, g3.magCapacity, g3.reloadTime, g3.accuracy, g3.gunAudio, g3.gunAudioSingle, g3.reloadAudio);
			break;
		}
	}

	void Shoot ()
	{
		ammo.shot (ammoID);
		timer = 0.0f;
		if (chamber) {			
			if (mag != 0)
				mag--;
			else
				chamber = false;				
		}
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		gunAudio.Play ();

		shootRay.origin = aim.transform.position;
		shootRay.direction = aim.transform.right;

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			enemyHealth enemyHealth = shootHit.collider.GetComponent <enemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.takeDamage (damage/*, shootHit.point*/);
			}
			Vector3 shotPoint;
			shotPoint.x = shootHit.point.x;
			shotPoint.y = shootHit.point.y;
			shotPoint.z = shootHit.point.z;
			gunLine.SetPosition (1, shotPoint);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}

		if (currAccuracy > accuracy) { 
			currAccuracy -= 1.0f;
		}
	}

	void setGun(int xGunID, int xAmmoID, float xRateOfFire, int xDamage, int xMagCapacity, float xReloadTime, float xAccuracy, AudioSource xGunAudio, AudioSource xGunAudioSingle, AudioSource xReloadAudio) {
		gunID = xGunID;
		ammoID = xAmmoID;
		rateOfFire = xRateOfFire;
		damage = xDamage;
		magCapacity = xMagCapacity;
		reloadTime = xReloadTime;
		accuracy = xAccuracy;
		gunAudio = xGunAudio;
		gunAudioSingle = xGunAudioSingle;
		reloadAudio = xReloadAudio;

		mag = magCapacity;
		chamber = true;
	}
}
