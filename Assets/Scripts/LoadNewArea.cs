using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;
    public string exitPoint;
    private PlayerMovement thePlayer;

    PlayerStartPoint startPointController;


    public GameObject player;

    // Use this for initialization
    void Start () {
        thePlayer = Object.FindObjectOfType<PlayerMovement>();
        startPointController = Object.FindObjectOfType<PlayerStartPoint>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

       if (other.gameObject.name == "Player")
       {
            thePlayer = Object.FindObjectOfType<PlayerMovement>();
            thePlayer.startPoint = exitPoint;

            player.GetComponent<PlayerMovement>().startPoint = exitPoint;

            Application.LoadLevel(levelToLoad);
        }
    }
}
