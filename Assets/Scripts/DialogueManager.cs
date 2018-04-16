using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager dialogueM;
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    [TextArea(3,10)]
    public string[] dialogLines;

    public int currentLine;

    public string levelName;

    public Canvas HUD;
    public GameObject player;
    public Canvas inv;
    public Canvas objectiveC;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        if (levelName.Equals("") || levelName.Equals(null))
        {
            levelName = player.GetComponent<PlayerMovement>().level;
        }

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<playerShoot>().enabled = false;
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
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<playerShoot>().enabled = true;
        SceneManager.LoadScene(levelName);
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
