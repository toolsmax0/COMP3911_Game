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

    static GameObject[] plastic_bag;

    static int randomvalueforpb = 0;

    static int randomvalue = 0;
    void Start()
    {
        scene_0 = GameObject.FindGameObjectsWithTag("SceneSetting_0");
        scene_1 = GameObject.FindGameObjectsWithTag("SceneSetting_1");
        scene_2 = GameObject.FindGameObjectsWithTag("SceneSetting_2");
        plastic_bag= GameObject.FindGameObjectsWithTag("plastic_bag");


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

        foreach (GameObject plasticbag in plastic_bag)
        {
            plasticbag.SetActive(false);
        }

    }

    void OnMouseDown()
    {
        if (opened == false)
        {
            opened = true;
            gameObject.GetComponent<Dooranimated>().OpenDoor();
            randomvalue = Random.Range(0, 3);
            randomvalueforpb = Random.Range(0, 16);
            
            for (int i=0; i<=randomvalueforpb; i++)
            {
                int newindex = Random.Range(0, plastic_bag.Length);
                plastic_bag[newindex].SetActive(true);
            }
            
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
        int num = 0;
        for (int i = 0; i <16; i++)
        {
            if (plastic_bag[i].activeSelf)
                num++;
        }
        return num;
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
