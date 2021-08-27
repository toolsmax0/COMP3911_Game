using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main Main panel of the scene
/// </summary>
public class BagPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/BagPanel";

    public BagPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnBack").onClick.AddListener(() =>
        {
            CountBag.resetPanel();
            PanelManager.Pop();
        });
    }
}
