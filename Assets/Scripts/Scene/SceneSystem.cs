using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scenario status management system
/// </summary>
public class SceneSystem
{
    /// <summary>
    /// Scene state class
    /// </summary>
    SceneState sceneState;

    /// <summary>
    /// Set the current scenario and enter the current scenario
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
