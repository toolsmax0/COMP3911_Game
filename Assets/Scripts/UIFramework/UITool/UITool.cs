using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI management tools, including operations to get a subobject component
/// </summary>
public class UITool
{
    /// <summary>
    /// The current active panel
    /// </summary>
    GameObject activePanel;

    public UITool(GameObject panel)
    {
        activePanel = panel;
    }

    /// <summary>
    /// Gets or adds a component to the current active panel
    /// </summary>
    /// <typeparam name="T">Component type</typeparam>
    /// <returns>component</returns>
    public T GetOrAddComponent<T>() where T : Component
    {
        if (activePanel.GetComponent<T>() == null)
            activePanel.AddComponent<T>();

        return activePanel.GetComponent<T>();
    }

    /// <summary>
    /// Finds a child object by name
    /// </summary>
    /// <param name="name">Child object name</param>
    /// <returns></returns>
    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans = activePanel.GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }

        Debug.LogWarning($"No child object named {name} can be found in {activePanel.name}");
        return null;
    }

    /// <summary>
    /// Gets the component of a child object by name
    /// </summary>
    /// <typeparam name="T">Component type</typeparam>
    /// <param name="name">The name of the child object</param>
    /// <returns></returns>
    public T GetOrAddComponentInChildren<T>(string name) where T : Component
    {
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();

            return child.GetComponent<T>();
        }
        return null;
    }
}
