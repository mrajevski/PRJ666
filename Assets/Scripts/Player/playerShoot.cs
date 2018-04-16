using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

	private float timer, switchTimer = 0.5f, currAccuracy = 100.0f, spread = 0.0f;
	private int range = 100, shootableMask;
	public int mag;  
	public bool chamber = true, reloading = false, aiming = false, sprinting = false, switching = false, menu = false, house = false, trigger = false;
	public GameObject backpack;
	private itemController inventory;
	private ammoController ammo;
	public Transform aim;
	Ray shootRay = new Ray();
	RaycastHit shootHit;
	LineRenderer gunLine;
	public AudioSource gunEmpty;

	void Start() {
		ammo = backpack.GetComponent<ammoController> ();
		inventory = backpack.GetComponent<itemController> ();
	}

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent <LineRenderer> ();
	}


	void Update ()
	{
		timer += Time.deltaTime;

		// Shoot //
		if(Input.GetKey(KeyCode.Mouse0) && timer >= inventory.equipment [inventory.g].gun.rateOfFire && Time.timeScale != 0 && !menu && !house) {
			switch (inventory.equipment [inventory.g].gun.fireMode) {
			case 0: // Full-auto //
				if (chamber && !sprinting && !reloading && !switching) {
					if (ammo.shot (inventory.equipment [inventory.g].gun.ammoID))
						Shoot ();
				}
				break;
			case 1: // Semi-auto //
				if (!trigger && chamber && !sprinting && !reloading && !switching) {
					if (ammo.shot (inventory.equipment [inventory.g].gun.ammoID))
						trigger = true;
					Shoot ();
				}
				break;
			case 2: // Shotgun //
				if (!trigger && chamber && !sprinting && !reloading && !switching) {
					if (ammo.shot (inventory.equipment [inventory.g].gun.ammoID))
						trigger = true;
					Shoot ();
				}
				break;
			default:
				break;
			}
			if (Input.GetKeyDown (KeyCode.Mouse0) && mag == 0 && !chamber)
				gunEmpty.Play ();
		}
		if (Input.GetKeyUp (KeyCode.Mouse0))
			trigger = false;

		// Reload //
		if (Input.GetKey(KeyCode.R) && ammo.ammo[inventory.equipment [inventory.g].gun.ammoID] != 0 && !reloading && !switching) {
			reload ();
			timer = 0.0f;
			reloading = true;
			inventory.equipment [inventory.g].gun.reloadAudio.Play ();
		}

		// Reload Timer //
		if (reloading) {
			if (timer >= inventory.equipment [inventory.g].gun.reloadTime)
				reloading = false;
		}

		// Rate of Fire //
		if (timer >= inventory.equipment [inventory.g].gun.rateOfFire * 0.1f + 0.02f) {
			disableShot();
		}

		// Aiming //
		if (Input.GetKeyDown(KeyCode.Mouse1) && !switching && !reloading && !sprinting && !menu) {
			aiming = true;
			currAccuracy += 5.0f;
		}
		if (Input.GetKeyUp(KeyCode.Mouse1)  && aiming && !switching && !reloading && !sprinting && !menu) {
			aiming = false;
			currAccuracy -= 5.0f;
		}

		// Accuracy Cone //
		if (currAccuracy < 100.0f)
        { 
			currAccuracy += 0.1f;
		}

		// Sprinting //
		if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) {
			sprinting = true;
		}
		if (!Input.GetKey(KeyCode.LeftShift) || (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))) {
			sprinting = false;
		}

		// Weapon Switching //
		if (Input.GetKeyDown(KeyCode.Alpha1) && !switching) {
			switching = true;
			timer = 0.0f;
			inventory.g = 0;
			chamber = false;
			reload ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && !switching) {
			switching = true;
			timer = 0.0f;
			inventory.g = 1;
			chamber = false;
			reload ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && !switching) {
			switching = true;
			timer = 0.0f;
			inventory.g = 2;
			chamber = false;
			reload ();
		}

		// Weapon Switching Timer //
		if (switching) {
			if (timer >= switchTimer)
				switching = false;			
		}

		// Check if in Menu //
		if (Input.GetKeyDown(KeyCode.Tab)) {
			menu = !menu;
		}
	}


	public void disableShot ()
	{
		gunLine.enabled = false;
	}

	void Shoot ()
	{
		timer = 0.0f;
		if (chamber)
        {			
			if (mag != 0)
				mag--;
			else
				chamber = false;				
		}
		gunLine.enabled = true;	
		gunLine.SetPosition (0, aim.position);

		inventory.equipment [inventory.g].gun.gunAudio.Play ();

		spread = (Random.Range(currAccuracy - 0.1f, 100.0f) - 100.0f);
		spread *= ((Random.Range (0, 10) < 5) ? -0.5f : 0.5f);
		aim.Rotate (new Vector3 (0, 0, spread));

		shootRay.origin = aim.transform.position;
		shootRay.direction = aim.transform.right;

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			enemyHealth enemyHealth = shootHit.collider.GetComponent <enemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.takeDamage (inventory.equipment [inventory.g].gun.damage);
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

		if (currAccuracy > inventory.equipment [inventory.g].gun.accuracy) { 
			currAccuracy -= 1.0f;
		}

		aim.Rotate (new Vector3 (0, 0, -spread));
	}

	public void setHouse(bool state) {
		house = state;
	}

	private void reload() {
		int ammoID = inventory.equipment [inventory.g].gun.ammoID,
		magCapacity = inventory.equipment [inventory.g].gun.magCapacity;

		if (ammo.ammo [ammoID] > magCapacity) {
			mag = (chamber) ? magCapacity : magCapacity - 1;
			chamber = true;
		} else if (ammo.ammo [ammoID] < magCapacity + 1) {
			mag = ammo.ammo [ammoID] - 1;
			chamber = true;
		} else {
			mag = 0;
			chamber = false;
		}
	}
}
