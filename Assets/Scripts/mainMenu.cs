using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button quitText;

    // Use this for initialization
    void Start() {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
    }

    public void StartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("main");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
