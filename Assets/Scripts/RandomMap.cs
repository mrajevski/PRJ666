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
    public Vector2 pos;
    public GameObject player;

    // Use this for initialization
    void Start () {
        //Names for first levels
        levelOne.Add("main");
        levelOne.Add("LucasMap1");
        levelOne.Add("ParmMap1");//Need to be added
        //levelOne.Add("MattMap1");//Need to be added

        //Names for second levels
        levelTwo.Add("LucasMap2");
        levelTwo.Add("KelvinLevel2");
        levelTwo.Add("ParmMap2");//Need to be added
        //levelTwo.Add("MattMap2");//Need to be added

        ////Names for level three
        levelThree.Add("LucasMap3");//Need to be added
        levelThree.Add("KelvinLevel3");//Need to be added
        //levelThree.Add("ParmMap3");//Need to be added
        //levelThree.Add("MattMap3");//Need to be added

        levelFour = "Final";

        player = GameObject.FindGameObjectWithTag("Player");
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
        string levelToLoad = "";

        if (player.GetComponent<PlayerMovement>().playerLevel == 0)
        {
            player.GetComponent<PlayerMovement>().playerLevel++;
        }
        if (player.GetComponent<PlayerMovement>().playerLevel == 1)
        {
            levelToLoad = randomLevel(levelTwo);
            level2RelocatePosition(levelToLoad);
        }
        if (player.GetComponent<PlayerMovement>().playerLevel == 2)
        {
            levelToLoad = randomLevel(levelThree);
            level2RelocatePosition(levelToLoad);
        }
        if (player.GetComponent<PlayerMovement>().playerLevel > 2)
        {
            levelToLoad = levelFour;
            level2RelocatePosition(levelToLoad);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = pos;
            player.GetComponent<PlayerMovement>().JerryCans = 0;
            player.GetComponent<PlayerMovement>().level = levelToLoad;
            if (player.GetComponent<PlayerMovement>().playerLevel == 1)
            {
                player.GetComponent<PlayerMovement>().playerLevel++;
                SceneManager.LoadScene("CutTwo");
            }
            else if (player.GetComponent<PlayerMovement>().playerLevel == 2)
            {
                player.GetComponent<PlayerMovement>().playerLevel++;
                SceneManager.LoadScene("CutThree");
            }
            else
            {
                SceneManager.LoadScene("CutFour");
            }
        }
    }

    public string randomFirstLevel()
    {
        return randomLevel(levelOne);
    }

    public void level2RelocatePosition(string level)
    {
        if (level.Equals("LucasMap2"))
            pos = new Vector2(-12.06f, 10.69f);
        else if (level.Equals("KelvinLevel2"))
            pos = new Vector2(-22.6f, 17.09f);
        else if (level.Equals("LucasMap3"))
            pos = new Vector2(-26.5f, -7.5f);
        else if (level.Equals("KelvinLevel3"))
            pos = new Vector2(-3.6f, -0.25f);
        else if (level.Equals("ParmMap2"))
            pos = new Vector2(27.41f, -21.58f);
        else if (level.Equals("Final"))
            pos = new Vector2(2.5f, -14.0f);
    }

    public Vector2 relocatePlayerPosition(string level)
    {
        if(level.Equals("main"))
            pos = new Vector2(-11.81f, -12f);
        else if (level.Equals("LucasMap1"))
            pos = new Vector2(-52, -5);
        else if (level.Equals("ParmMap1"))
            pos = new Vector2(18.68f, -13.03f);

        return pos;
    }
}
