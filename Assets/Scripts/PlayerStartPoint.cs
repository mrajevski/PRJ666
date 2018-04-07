using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerMovement thePlayer;
    private CameraMovement theCamera;

    public GameObject player;


    public string pointName;

    public GameObject startPoint;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        thePlayer = Object.FindObjectOfType<PlayerMovement>();
        if (thePlayer.startPoint.Equals(""))
        {
            thePlayer.startPoint = player.GetComponent<PlayerMovement>().startPoint;
        }
        if (thePlayer.startPoint == pointName)
        {
            //thePlayer.transform.position = transform.position;
            player.transform.position = transform.position;

            theCamera = Object.FindObjectOfType<CameraMovement>();
            theCamera.transform.position = new Vector3
                        (transform.position.x,
                        transform.position.y,
                        theCamera.transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
