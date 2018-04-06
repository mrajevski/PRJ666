using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GameIsPaused = false; 
    public GameObject pauseMenuUI;
    public GameObject settingUI;
    public Button resumeText;
    public Button exitText;
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Start() {
        pauseMenuUI.SetActive(false);
        exitText = exitText.GetComponent<Button>();
        resumeText = resumeText.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenuUI.SetActive(true);
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void toSetting()
    {
        settingUI.SetActive(true);
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
