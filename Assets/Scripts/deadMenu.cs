using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deadMenu : MonoBehaviour {

    public Button menu;

	// Use this for initialization
	void Start () {
		menu = menu.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toMenuPressed()
    {
        SceneManager.LoadScene("menu");
    }
}
