using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{

    public GameObject ingameMenu;

    public GameObject camera;
    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                this.paused = true;
                Time.timeScale = 0;
                ingameMenu.SetActive(true);
                //disable first person look
                camera.GetComponent<FirstPersonLook>().enabled = false;

            }
            else
            {
                OnResume();
            }
        }
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*  set rendering quality according to dropdown value*/
    public void QualityTransform(int value)
    {
        switch (value)
        {
            case 0:
                QualitySettings.SetQualityLevel(1, true);
                break;
            case 1:
                QualitySettings.SetQualityLevel(3, true);
                break;
            case 2:
                QualitySettings.SetQualityLevel(5, true);
                break;
                // not yet supported
                // case 3:
                //     QualitySettings.SetQualityLevel(3, true);
                //     break;
                // case 4:
                //     QualitySettings.SetQualityLevel(4, true);
                //     break;
                // case 5:
                //     QualitySettings.SetQualityLevel(5, true);
                //     break;
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }


    public void OnResume()
    {
        Time.timeScale = 1f;
        this.paused = false;
        ingameMenu.SetActive(false);
        //enable first person look
        camera.GetComponent<FirstPersonLook>().enabled = true;
    }
}
