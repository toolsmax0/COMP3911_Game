using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycasthit : MonoBehaviour
{
    private bool opened = false;

    GameObject[] scene_0;

    GameObject[] scene_1;

    GameObject[] scene_2;

    void Start()
    {
        scene_0 = GameObject.FindGameObjectsWithTag("SceneSetting_0");
        scene_1 = GameObject.FindGameObjectsWithTag("SceneSetting_1");
        scene_2 = GameObject.FindGameObjectsWithTag("SceneSetting_2");
        foreach (GameObject scene0 in scene_0)
        {
            scene0.SetActive(true);
        }
        foreach (GameObject scene1 in scene_1)
        {
            scene1.SetActive(true);
        }
        foreach (GameObject scene2 in scene_2)
        {
            scene2.SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if (opened == false)
        {
            opened = true;
            gameObject.GetComponent<Dooranimated>().OpenDoor();
            int randomvalue = Random.Range(0, 3);
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
}
