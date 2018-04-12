using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objective : MonoBehaviour {
    public int jerryCan;

	// Use this for initialization
	void Start () {
        jerryCan = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            jerryCan++;
            Destroy(other);
        }
    }
}
