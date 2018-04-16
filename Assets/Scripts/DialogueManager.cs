using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    [TextArea(3,10)]
    public string[] dialogLines;

    public int currentLine;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }

        if (currentLine >= dialogLines.Length)
        {
            dialogActive = false;
            dBox.SetActive(false);

            currentLine = 0;
            StartCoroutine(JumpToMain());
        }
        dText.text = dialogLines[currentLine];
	}

    IEnumerator JumpToMain()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("menu");
    }
}
