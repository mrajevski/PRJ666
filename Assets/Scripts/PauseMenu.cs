using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public Scene scene;
    public PlayerMovement playerMovement;
    public playerHealth playerHealth;
    public static bool GameIsPaused; 
    public GameObject pauseMenuUI;
    public GameObject settingUI;
    public GameObject player;
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
        playerMovement = UnityEngine.Object.FindObjectOfType<PlayerMovement>();
        playerHealth = UnityEngine.Object.FindObjectOfType<playerHealth>();
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
     /*
        //Saving from playerPref
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Health", playerHealth.health);
        PlayerPrefs.SetFloat("Armor", playerHealth.armor);
        PlayerPrefs.SetString("Scene", scene.name); 
        PlayerPrefs.Save();
        */
        //Save to file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        PlayerData data = new PlayerData();
        data.health = playerHealth.health;
        data.armor  = playerHealth.armor;
        data.currentPositionX = GameObject.Find("Player").transform.position.x;
        data.currentPositionY = GameObject.Find("Player").transform.position.y;
        data.currentScene = scene.name;

        bf.Serialize(file, data);
        file.Close();
      
    }


    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float armor;
    public string currentScene;
    public float currentPositionX;
    public float currentPositionY;
}