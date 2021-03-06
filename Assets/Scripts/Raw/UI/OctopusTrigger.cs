using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
this is the trigger for player entering the zone to manipulate the octopus.
*/
public class OctopusTrigger : MonoBehaviour
{
    public GameObject interactionPanel;

    public BasePanel cashMenu;

    private AudioSource octopusAudio;

    private bool isActive = false;

    private static bool paused = false;

    void Awake()
    {
        interactionPanel.SetActive(false);

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
        if (other.gameObject.tag == "Player" && !isActive)
        {
            //enable the UI
            isActive = true;
            interactionPanel.SetActive(true);
            if (!octopusAudio.isPlaying && Time.timeScale != 0)
                octopusAudio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //disable the UI
            isActive = false;
            interactionPanel.SetActive(false);
        }
    }

    private void ToTask()
    {
        paused = true;
        Time.timeScale = 0;
        cashMenu = new TaskPanel();
        GameRoot.Instance.Push (cashMenu);
    }

    private void OutTask()
    {
        paused = false;
        cashMenu.Pop();
    }

    public static void resetPause()
    {
        paused = false;
    }
}
