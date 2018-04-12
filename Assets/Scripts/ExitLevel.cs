using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if ((Input.GetKeyDown(KeyCode.E))&& player.GetComponent<PlayerMovement>().JerryCans > 2)
            {
                SceneManager.LoadScene("Shop");
                Vector2 pos = new Vector2(-1.5f, -0.5f);
                player.transform.position = pos;
            }
        }
    }
}
