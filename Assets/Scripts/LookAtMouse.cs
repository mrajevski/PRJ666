using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    Vector3 mousePos;
    Camera cam;
    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = cam.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        rb2d.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2
            ((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}
