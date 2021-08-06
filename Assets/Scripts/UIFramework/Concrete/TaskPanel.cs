using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Task pane
/// </summary>
public class TaskPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/TaskPanel";

    public TaskPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnExit").onClick.AddListener(() =>
        {
            PanelManager.Pop();
        });
    }
}
