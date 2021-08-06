using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores all UI information and can create or destroy uIs
/// </summary>
public class UIManager
{
    /// <summary>
    /// A dictionary that stores all UI information, and each UI information has a GameObject
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;

    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }

    /// <summary>
    /// Get a UI object
    /// </summary>
    /// <param name="type">The UI information</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas does not exist, please look carefully for this object");
            return null;
        }
        if (dicUI.ContainsKey(type))
            return dicUI[type];
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        ui.name = type.Name;
        dicUI.Add(type, ui);
        return ui;
    }

    /// <summary>
    /// Destroy a UI object
    /// </summary>
    /// <param name="type">The UI information</param>
    public void DestroyUI(UIType type)
    {
        if (dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }
}
