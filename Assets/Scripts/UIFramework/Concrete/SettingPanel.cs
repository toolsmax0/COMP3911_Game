using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SettingPanel";

    public SettingPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnBack").onClick.AddListener(() =>
        {
            InGameUI.resetPause();
            PanelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Toggle>("ToggleLow").onValueChanged.AddListener(isOn =>
    {
        if (isOn)
        {

            Settings.getInstance().settings["jumpqueue"] = true;
            Settings.getInstance().settings["randomMoney"] = true;
        }
    });

        UITool.GetOrAddComponentInChildren<Toggle>("ToggleMid").onValueChanged.AddListener(isOn =>
    {
        if (isOn)
        {

            Settings.getInstance().settings["jumpqueue"] = true;
            Settings.getInstance().settings["randomMoney"] = true;
        }
    });

        UITool.GetOrAddComponentInChildren<Toggle>("ToggleHigh").onValueChanged.AddListener(isOn =>
    {
        if (isOn)
        {

            Settings.getInstance().settings["jumpqueue"] = true;
            Settings.getInstance().settings["randomMoney"] = true;
        }
    });
    }

}
