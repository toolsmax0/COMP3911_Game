using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Start scene
/// </summary>
public class StartScene : SceneState
{
    /// <summary>
    /// The scene name
    /// </summary>
    readonly string sceneName = "Start";
    PanelManager panelManager;

    public override void OnEnter()
    {
        Time.timeScale = 0;
        Camera.main.GetComponent<FirstPersonLook>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;

        panelManager = new PanelManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            panelManager.Push(new StartPanel());
            GameRoot.Instance.SetAction(panelManager.Push);
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panelManager.PopAll();
    }

    /// <summary>
    /// Method to execute after the scene has been loaded
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new StartPanel());
        GameRoot.Instance.SetAction(panelManager.Push);
        Debug.Log($"The {sceneName} scene is loaded!");
    }
}
