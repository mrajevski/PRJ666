using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdAll : MonoBehaviour {

    public static holdAll hold;
    public GameObject HUD;
    public GameObject player;
    public GameObject inv;
    public GameObject objectiveC;

    public static bool isExist;
    // Use this for initialization
    void Start () {
        if (!isExist)
        {
            isExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setCanvasInvisible()
    {
        inv.SetActive(false);
        HUD.SetActive(false);
        objectiveC.SetActive(false);
    }

    public void setCanvasVisible()
    {
        inv.SetActive(true);
        HUD.SetActive(true);
        objectiveC.SetActive(true);
    }
}
