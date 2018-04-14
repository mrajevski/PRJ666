﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement movementControl;

	public Vector2 currentPos, movement;
	Vector3 mousePos;
	Rigidbody player;
	Camera cam;
	int floorMask;
	public float speed;
    public Animator animator;
	public string startPoint;
	public static bool playerExists;
    public int JerryCans;
    //manual use only
    public int spriteUse = 1;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
	void Start () {
		cam = Camera.main;
		player = GetComponent<Rigidbody> ();
		floorMask = LayerMask.GetMask ("Floor");
        JerryCans = 0;

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		}
		else {
			Destroy (gameObject);
		}


	}

    // Update is called once per frame
    void Update()
    {
		// Aim check //
		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			speed *= 0.5f;
		}
		if (Input.GetKeyUp(KeyCode.Mouse1)) {
			speed *= 2.0f;
		}
		// Sprint check //
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			speed *= 1.25f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			speed *= 0.8f;
		}

		// Movement //
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		currentPos.Set (transform.position.x, transform.position.y);
		move (h, v);
		rotate ();

		// Animation //
		if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D))) {
			if (spriteUse == 0)
				animator.SetInteger ("AnimState", 1);
			else
				animator.SetInteger ("AnimState", 4);
		}
		else {
			if (spriteUse == 0)
				animator.SetInteger ("AnimState", 0);
			else
				animator.SetInteger ("AnimState", 3);
		}
    }

	void move(float horizontal, float vertical) {
		movement.Set (horizontal, vertical);
		movement = movement.normalized * speed * Time.deltaTime;
		player.MovePosition(currentPos + movement);
	}

	void rotate() {
		Ray camRay = Camera.main.ScreenPointToRay (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, 100.0f, floorMask)) {
			player.rotation = Quaternion.Euler (0.0f, 0.0f, Mathf.Atan2((floorHit.point.y - transform.position.y), (floorHit.point.x - transform.position.x)) * Mathf.Rad2Deg);
		}
	}

    public Animator getAnimator()
    {
        return GetComponent<Animator>();
    }
}
