using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMap : MonoBehaviour {

    public static RandomMap randomMap;

    public List<string> levelOne;
    public List<string> levelTwo;
    public List<string> levelThree;
    public string levelFour;
    public int currentLevel;
    public Vector2 pos;

    // Use this for initialization
    void Start () {
        //Names for first levels
        levelOne.Add("main");
        levelOne.Add("LucasMap1");
        levelOne.Add("main");//Need to be added
        levelOne.Add("main");//Need to be added

        //Names for second levels
        levelTwo.Add("LucasMap2");
        levelTwo.Add("KelvinLevel2");
        //levelTwo.Add("ParmMap2");//Need to be added
        //levelTwo.Add("MattMap2");//Need to be added

        ////Names for level three
        //levelThree.Add("LucasMap3");//Need to be added
        //levelThree.Add("KelvinLevel3");//Need to be added
        //levelThree.Add("ParmMap3");//Need to be added
        //levelThree.Add("MattMap3");//Need to be added

        levelFour = "main";

        currentLevel = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public string randomLevel (List<string> level)
    {
        int randomIndex = Random.Range(0, 2);
        return level[randomIndex];
    }
    void OnTriggerStay(Collider other)
    {
        string levelToLoad;

        if (currentLevel == 1)
            levelToLoad = randomLevel(levelTwo);
        else if (currentLevel == 2)
            levelToLoad = randomLevel(levelOne);
        else
            levelToLoad = levelFour;

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentLevel++;
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public string randomFirstLevel()
    {
        return randomLevel(levelOne);
    }

    public Vector2 relocatePlayerPosition(string level)
    {
        if(level.Equals("main"))
            pos = new Vector2(-11.81f, -12f);
        else if (level.Equals("LucasMap1"))
            pos = new Vector2(-52, -5);

        return pos;

    }
}
