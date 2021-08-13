using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
this is the trigger for player entering the zone to manipulate the octopus.
*/
public class OctopusTrigger : MonoBehaviour
{
    public GameObject textObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //enable the UI
            textObj.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //disable the UI
            textObj.SetActive(false);

        }
    }
}
