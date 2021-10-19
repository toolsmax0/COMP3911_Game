using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Task pane
/// </summary>
public class TaskPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/TaskPanel";

    public static int target;

    public TaskPanel() :
        base(new UIType(path))
    {
    }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnReturn").onClick.AddListener(() =>
        {
            OctopusTrigger.resetPause();
            PanelManager.Pop();
        });
        UITool.GetOrAddComponentInChildren<Button>("BtnHome").onClick.AddListener(() =>
        {
            OctopusTrigger.resetPause();
            PanelManager.PopAll();
            PanelManager.Push(new MainPanel());
        });

        UITool.GetOrAddComponentInChildren<Button>("Button0").onClick.AddListener(() =>
        {
            addnumber("0");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button1").onClick.AddListener(() =>
        {
            addnumber("1");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button2").onClick.AddListener(() =>
        {
            addnumber("2");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button3").onClick.AddListener(() =>
        {
            addnumber("3");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button4").onClick.AddListener(() =>
        {
            addnumber("4");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button5").onClick.AddListener(() =>
        {
            addnumber("5");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button6").onClick.AddListener(() =>
        {
            addnumber("6");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button7").onClick.AddListener(() =>
        {
            addnumber("7");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button8").onClick.AddListener(() =>
        {
            addnumber("8");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button9").onClick.AddListener(() =>
        {
            addnumber("9");
        });
        UITool.GetOrAddComponentInChildren<Button>("Button.").onClick.AddListener(() =>
        {
            addnumber(".");
        });
        UITool.GetOrAddComponentInChildren<Button>("ButtonX").onClick.AddListener(() =>
        {
            addnumber("X");
        });
        UITool.GetOrAddComponentInChildren<Button>("ButtonConfirm").onClick.AddListener(() =>
        {
            confirm();
            addnumber("X");
        });
    }

    private void addnumber(string btntype)
    {
        TMP_Text content =
            UITool.GetOrAddComponentInChildren<TMP_Text>("ContentText");
        if (btntype.Equals("X"))
            content.text = "0";
        else if (btntype.Equals(".") && content.text.Contains("."))
            return;
        else if (content.text.Equals("0") && !btntype.Equals("."))
            content.text = btntype;
        else
            content.text += btntype;
    }

    private void confirm()
    {
        int t = Int32.Parse(UITool.GetOrAddComponentInChildren<TMP_Text>("ContentText").text);
        Debug.Log("Target " + target + ", " + t + " paid, " + Dialogflow.money + " left.");
        // if (Dialogflow.state == Dialogflow.State.paying && 
        //     Dialogflow.money == 0 && t == target)
        if(t == Dialogflow.money)
        {
            Dialogflow.state = Dialogflow.State.exit;
            GameObject.FindGameObjectWithTag("Cashier").GetComponent<AudioSource>().Play();
            Debug.Log("exit");
        }
    }
}
