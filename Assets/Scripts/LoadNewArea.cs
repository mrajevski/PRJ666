using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;
    public string exitPoint;
    private Vector2 pos;
    private PlayerMovement thePlayer;

    PlayerStartPoint startPointController;

    // Use this for initialization
    void Start () {
        thePlayer = Object.FindObjectOfType<PlayerMovement>();
        startPointController = Object.FindObjectOfType<PlayerStartPoint>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

       if (other.gameObject.name == "Player")
       {
            thePlayer = Object.FindObjectOfType<PlayerMovement>();
            thePlayer.startPoint = exitPoint;
            Application.LoadLevel(levelToLoad);
        }
    }
}
