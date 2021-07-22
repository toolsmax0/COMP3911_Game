using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
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
                QualitySettings.SetQualityLevel(0, true);
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
}
