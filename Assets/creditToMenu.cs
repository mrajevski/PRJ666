using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditToMenu : MonoBehaviour {

    public double counter;
	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime + 0.1;
        if (counter >= 235)
        {
            SceneManager.LoadScene("menu");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
