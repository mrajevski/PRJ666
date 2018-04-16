using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasIndicator : MonoBehaviour {

    public static bool hudExists;
    public Text currentGas;
    public GameObject player;
    public int counter;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!hudExists)
        {
            hudExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        counter = player.GetComponent<PlayerMovement>().JerryCans;

        currentGas.text = counter + "/3";
	}
}
