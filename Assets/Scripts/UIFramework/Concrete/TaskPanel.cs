using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Task pane
/// </summary>
public class TaskPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/TaskPanel";

    public TaskPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnReturn").onClick.AddListener(() =>
        {
            PanelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("BtnHome").onClick.AddListener(() =>
        {
            PanelManager.PopAll();
            PanelManager.Push(new StartPanel());
        });

        TMP_Text content = UITool.GetOrAddComponentInChildren<TMP_Text>("ContentText");
        UITool.GetOrAddComponentInChildren<Button>("Button0").onClick.AddListener(() =>
        {
            content.text += "0";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button1").onClick.AddListener(() =>
        {
            content.text += "1";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button2").onClick.AddListener(() =>
        {
            content.text += "2";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button3").onClick.AddListener(() =>
        {
            content.text += "3";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button4").onClick.AddListener(() =>
        {
            content.text += "4";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button5").onClick.AddListener(() =>
        {
            content.text += "5";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button6").onClick.AddListener(() =>
        {
            content.text += "6";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button7").onClick.AddListener(() =>
        {
            content.text += "7";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button8").onClick.AddListener(() =>
        {
            content.text += "8";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button9").onClick.AddListener(() =>
        {
            content.text += "9";
        });
        UITool.GetOrAddComponentInChildren<Button>("Button.").onClick.AddListener(() =>
        {
            content.text += ".";
        });
        UITool.GetOrAddComponentInChildren<Button>("ButtonX").onClick.AddListener(() =>
        {
            content.text = "0";
        });
        UITool.GetOrAddComponentInChildren<Button>("ButtonConfirm").onClick.AddListener(() =>
        {
            content.text = "0";
        });
    }
}
