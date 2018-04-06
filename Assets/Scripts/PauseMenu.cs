using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public Scene scene;
    public PlayerMovement playerMovement;
    public static bool GameIsPaused; 
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
        GameIsPaused = false;
        scene = SceneManager.GetActiveScene();
        playerMovement = Object.FindObjectOfType<PlayerMovement>();
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

    public void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Scene", scene.name);
        PlayerPrefs.Save();
    }


    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
