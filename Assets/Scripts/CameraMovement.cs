using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	GameObject target;

	public static bool cameraExists;

	// Use this for initialization
	void Start () {
		if (!cameraExists) {
			target = GameObject.FindGameObjectWithTag ("Player");
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		}
		else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -6.0f);
	}
}
