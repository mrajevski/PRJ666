﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class mainMenu : MonoBehaviour {

    public SettingsMenu settingsMenu;
    public Canvas quitMenu;
    public Button startText;
    public Button quitText;

    public playerHealth healthController;
    public PlayerMovement playerController;

    public GameObject HUD;
    public GameObject player;
    public GameObject inv;
    public GameObject objectiveC;

    public RandomMap randomMap;

    // Use this for initialization
    void Start() {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        settingsMenu = Object.FindObjectOfType<SettingsMenu>();
        quitMenu.enabled = false;
        inv.SetActive(false);
        healthController = Object.FindObjectOfType<playerHealth>();
        playerController = Object.FindObjectOfType<PlayerMovement>();
        randomMap = Object.FindObjectOfType<RandomMap>();
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
        string level = randomMap.randomFirstLevel();
        playerController.level = level;
        playerController.transform.position = randomMap.relocatePlayerPosition(level);

        healthController.health = 100;
        healthController.armor = 100;

        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<playerShoot>().enabled = false;
        playerController.animator.ResetTrigger("AnimState");
        inv.SetActive(true);
        HUD.SetActive(true);
        objectiveC.SetActive(true);
        SceneManager.LoadScene("CutOne");

        if (PlayerPrefs.HasKey("Volume"))
            settingsMenu.SetVolume(PlayerPrefs.GetFloat("Volume"));
    }

    public void Load()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerController.animator.ResetTrigger("AnimState");
        inv.SetActive(true);
        HUD.SetActive(true);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<playerShoot>().enabled = true;
        //Loading from file
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {

            Time.timeScale = 1f;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            playerHealth.healthController.health = data.health;
            playerHealth.healthController.armor = data.armor;
            playerController.JerryCans = data.jerryCan;
            string scene = data.currentScene;
            Vector2 pos;
            pos.x = data.currentPositionX;
            pos.y = data.currentPositionY;

            playerController.transform.position = pos;

            //= data.currentPositionX;
            //PlayerMovement.movementControl.currentPos.y = data.currentPositionY;

            SceneManager.LoadScene(scene);
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
