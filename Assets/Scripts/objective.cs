using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective : MonoBehaviour
{

    public GameObject player;
    public int jerryCans;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jerryCans = player.GetComponent<PlayerMovement>().JerryCans;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                jerryCans = 1;
                player.GetComponent<PlayerMovement>().JerryCans += jerryCans;
                Destroy(this.gameObject);
            }
        }

    }
}