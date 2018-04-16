using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAll : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if ((Input.GetKeyDown(KeyCode.E)))
            {
                SceneManager.LoadScene("CutScene");
            }
        }
    }
}
