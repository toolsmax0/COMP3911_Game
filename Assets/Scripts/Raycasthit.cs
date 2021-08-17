using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Raycasthit : MonoBehaviour
{
    [SerializeField] private Dooranimated door;

    private const float _maxDistance = 5000;
    private Animator animator;
    private bool opened = false;
    GameObject [] scene_0;
    GameObject [] scene_1  ;
    GameObject [] scene_2;

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

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            if (hit.transform.tag == "Door" && Input.GetMouseButtonDown(0))
            {
                if (opened == false)
                {
                    opened = true;
                    door.OpenDoor();
                    int randomvalue = Random.Range(0, 2);
                    switch (randomvalue)
                    {

                        case 0:
                            foreach (GameObject scene0 in scene_0)
                            {
                                scene0.SetActive(true);
                            }
                            foreach (GameObject scene1 in scene_1)
                            {
                                scene1.SetActive(false);
                            }
                            foreach (GameObject scene2 in scene_2)
                            {
                                scene2.SetActive(false);
                            }
                            break;

                        case 1:
                            foreach (GameObject scene1 in scene_1)
                            {
                                scene1.SetActive(true);
                            }
                            foreach (GameObject scene0 in scene_0)
                            {
                                scene0.SetActive(false);
                            }
                            foreach (GameObject scene2 in scene_2)
                            {
                                scene2.SetActive(false);
                            }
                            break;

                        case 2:
                            foreach (GameObject scene2 in scene_2)
                            {
                                scene2.SetActive(true);
                            }
                            foreach (GameObject scene1 in scene_1)
                            {
                                scene1.SetActive(false);
                            }
                            foreach (GameObject scene0 in scene_0)
                            {
                                scene0.SetActive(false);
                            }
                            break;
                    }
                }
                else
                {
                    opened = false;
                    door.CloseDoor();
                }
            }
        }
    }
}
