using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene status management system
/// </summary>
public class SceneSystem
{
    /// <summary>
    /// Scene state class
    /// </summary>
    SceneState sceneState;

    /// <summary>
    /// Set the current scene and enter the current scene
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(SceneState state)
    {
        // if (sceneState != null)
        //     sceneState.OnExit();
        // sceneState = state;
        // if (sceneState != null)
        //     sceneState.OnEnter();
        sceneState?.OnExit();
        sceneState = state;
        sceneState?.OnEnter();
    }
}
