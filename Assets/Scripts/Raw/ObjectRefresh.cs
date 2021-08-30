using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRefresh : MonoBehaviour
{
    private bool opened = false;

    GameObject[] scene_0;

    GameObject[] scene_1;

    GameObject[] scene_2;

    static int randomvalue = 0;
    void Start()
    {
        scene_0 = GameObject.FindGameObjectsWithTag("SceneSetting_0");
        scene_1 = GameObject.FindGameObjectsWithTag("SceneSetting_1");
        scene_2 = GameObject.FindGameObjectsWithTag("SceneSetting_2");

        
        foreach (GameObject scene0 in scene_0)
        {
            scene0.SetActive(false);
        }
        foreach (GameObject scene1 in scene_1)
        {
            scene1.SetActive(false);
        }
        foreach (GameObject scene2 in scene_2)
        {
            scene2.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (opened == false)
        {
            opened = true;
            gameObject.GetComponent<Dooranimated>().OpenDoor();
            randomvalue = Random.Range(0, 3);

            foreach (GameObject scene0 in scene_0)
            {
                scene0.SetActive(randomvalue == 0);
            }
            foreach (GameObject scene1 in scene_1)
            {
                scene1.SetActive(randomvalue == 1);
            }
            foreach (GameObject scene2 in scene_2)
            {
                scene2.SetActive(randomvalue == 2);
            }
        }
        else
        {
            opened = false;
            gameObject.GetComponent<Dooranimated>().CloseDoor();
        }
    }

    static public int GetNumOfBags() // Get the number of plastic bags on the table
    {
        if (randomvalue == 0)
            return 4;
        if (randomvalue == 1)
            return 7;
        else
            return 5;   
    }

    static public int GetNumOfBrokenBottles()
    {
        if (randomvalue == 0)
            return 3;
        if (randomvalue == 1)
            return 3;
        else
            return 0;
    }

    static public int GetNumOfBrokenCreams()
    {
        if (randomvalue == 0)
            return 0;
        if (randomvalue == 1)
            return 2;
        else
            return 0;
    }

    static public int GetNumOfBrokenPaperBags()
    {
        if (randomvalue == 0)
            return 0;
        if (randomvalue == 1)
            return 0;
        else
            return 2;
    }

    static public int GetNumOfBrokenBuckets()
    {
        if (randomvalue == 0)
            return 0;
        if (randomvalue == 1)
            return 0;
        else
            return 2;
    }

    static public int GetNumOfBrokenBoxes()
    {
        if (randomvalue == 0)
            return 0;
        if (randomvalue == 1)
            return 0;
        else
            return 2;   
    }
    static public int GetNumOfBrokenPaperRolls()
    {
        if (randomvalue == 0)
            return 3;
        if (randomvalue == 1)
            return 0;
        else
            return 0;
    }
}
