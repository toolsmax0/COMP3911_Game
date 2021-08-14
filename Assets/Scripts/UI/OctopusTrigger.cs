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
    public GameObject cashMenu;
    private AudioSource octopusAudio;
    private bool isActive = false;


    private bool paused = false;


    void Awake()
    {
        textObj.SetActive(false);
        //get the audio component
        octopusAudio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.F))
        {
            if (!paused)
            {
                ToTask();
            }
            else
            {
                OutTask();
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //enable the UI
            isActive = true;
            textObj.SetActive(true);
            octopusAudio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //disable the UI
            isActive = false;
            textObj.SetActive(false);
        }
    }

    private void ToTask()
    {
        textObj.SetActive(false);
        this.paused = true;
        Time.timeScale = 0;
        cashMenu.SetActive(true);
        //disable first person look
        Camera.main.GetComponent<FirstPersonLook>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OutTask()
    {
        textObj.SetActive(true);

        Time.timeScale = 1f;
        this.paused = false;
        cashMenu.SetActive(false);
        //enable first person look
        Camera.main.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
