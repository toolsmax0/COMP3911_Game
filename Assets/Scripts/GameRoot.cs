using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Something that manages the whole picture
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }
    /// <summary>
    /// Scene manager
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }
    /// <summary>
    /// Display a panel
    /// </summary>
    public UnityAction<BasePanel> Push { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        SceneSystem = new SceneSystem();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }

    /// <summary>
    /// Setting up a Push
    /// </summary>
    /// <param name="push"></param>
    public void SetAction(UnityAction<BasePanel> push)
    {
        Push = push;
    }
}
