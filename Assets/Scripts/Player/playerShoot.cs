using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

	public float reloadTime, accuracy, currAccuracy = 100.0f, rateOfFire;
	public int range = 100, damage, magCapacity, mag, ammoID, gunID;
	public short fireMode;
	public Transform aim, player;
	bool chamber = true, reloading = false, aiming = false, sprinting = false, switching = false, menu = false, house = false;
	public GameObject backpack;
	private itemController inventory;
	private ammoController ammo;
	float timer, switchTimer = 2.5f;
	Ray shootRay = new Ray();
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	public gunObject g1, g2, g3;
	public AudioSource gunAudio, gunEmpty, reloadAudio;
	float shotDisplayTime = 0.1f;
	private Transform playerAccuracy;
	public float spread = 0.0f;

	void Start() {
		ammo = backpack.GetComponent<ammoController> ();
		inventory = backpack.GetComponent<itemController> ();
		/*if (inventory.equipment [0].itemID != -1)
			g1 = inventory.equipment [0].gun;
		else
			g1 = new gunObject ();

		if (inventory.equipment [1].itemID != -1)
			g2 = inventory.equipment [1].gun;
		else
			g2 = new gunObject ();

		if (inventory.equipment [2].itemID != -1)
			g3 = inventory.equipment [2].gun;
		else
			g3 = new gunObject ();*/
	}

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
		if(Input.GetKey(KeyCode.Mouse0) && timer >= rateOfFire && Time.timeScale != 0 && !menu && !house) {
			if (chamber && !sprinting && !reloading && !switching) {
				if (ammo.shot (ammoID))
					Shoot();
			}
			else if (Input.GetKeyDown(KeyCode.Mouse0) && mag == 0 && !chamber) {
				timer = 0.0f;
				gunEmpty.Play ();
			}
		}

		// Reload //
		if (Input.GetKey(KeyCode.R) && !reloading && !switching) {
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
		if (Input.GetKeyDown(KeyCode.Mouse1) && !switching && !reloading && !sprinting && !menu) {
			aiming = true;
			currAccuracy += 5.0f;
		}
		if (Input.GetKeyUp(KeyCode.Mouse1)  && aiming && !switching && !reloading && !sprinting && !menu) {
			aiming = false;
			currAccuracy -= 5.0f;
		}

		// Accuracy Cone //
		if (currAccuracy < 100.0f) { 
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
			setGun (g1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && !switching) {
			switching = true;
			timer = 0.0f;
			setGun (g2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && !switching) {
			switching = true;
			timer = 0.0f;
			setGun (g3);
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
		if (chamber) {			
			if (mag != 0)
				mag--;
			else
				chamber = false;				
		}
		gunLine.enabled = true;	
		gunLine.SetPosition (0, aim.position);

		gunAudio.Play ();

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

		aim.Rotate (new Vector3 (0, 0, -spread));
	}

	void setGun(gunObject g) {
		gunID = g.gunID;
		ammoID = g.ammoID;
		rateOfFire = g.rateOfFire;
		damage = g.damage;
		magCapacity = g.magCapacity;
		reloadTime = g.reloadTime;
		accuracy = g.accuracy;
		gunAudio = g.gunAudio;
		reloadAudio = g.reloadAudio;

		mag = magCapacity;
		chamber = true;
	}

	public void setHouse(bool state) {
		house = state;
	}
}
