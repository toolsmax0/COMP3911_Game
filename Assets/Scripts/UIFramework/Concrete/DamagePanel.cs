using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main Main panel of the scene
/// </summary>
public class DamagePanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/DamagePanel";
    public GameObject script;

    public DamagePanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnBack").onClick.AddListener(() =>
        {
            CountDamage.resetPanel();
            PanelManager.Pop();
        });
    }
}
