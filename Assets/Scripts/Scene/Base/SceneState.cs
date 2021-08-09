using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene: the state
/// </summary>
public abstract class SceneState
{
    /// <summary>
    /// The operation performed when the scene enters
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    /// Operations performed when a scene exits
    /// </summary>
    public abstract void OnExit();
}
