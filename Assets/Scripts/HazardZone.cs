using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardZone : MonoBehaviour {

    public GameObject player;
    public double damageDealt;
    public BarScript healthbar;
    public GameObject backpack;
    itemController items;
    private float counter;

    // Use this for initialization
    void Start () {
        counter = 0;
        damageDealt = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        healthbar = FindObjectOfType<BarScript>();
        backpack = player.transform.Find("Backpack").gameObject;
        items = backpack.GetComponent<itemController>();
    }

    // Update is called once per frame
    void Update () {
        counter++;
        damageDealt = Time.deltaTime + 0.1;
	}


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            if (!items.mask)
            {
                healthbar.posionState = true;
                //if ()//TODO: Add when implement the inv
                if (counter % 2 == 0)
                {
                    player.GetComponent<playerHealth>().posionTick((float)damageDealt);
                }
            }
        }
        else
        {
            healthbar.posionState = false;
        }
    }

}
