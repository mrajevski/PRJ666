using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMap : MonoBehaviour {

    public List<string> levelOne;
    public List<string> levelTwo;
    public List<string> levelThree;
    public string levelFour;
    public int currentLevel;
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

        levelFour = "Final";

        currentLevel = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public string randomLevel (List<string> level)
    {
        int randomIndex = Random.Range(0, 3);
        return level[randomIndex];
    }
    void OnTriggerEnter(Collider other)
    {
        string levelToLoad;
        if (currentLevel == 0)
            levelToLoad = randomLevel(levelOne);
        else if (currentLevel == 1)
            levelToLoad = randomLevel(levelOne);
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
}
