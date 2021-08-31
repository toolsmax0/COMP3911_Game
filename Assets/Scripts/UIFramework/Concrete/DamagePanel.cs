using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main Main panel of the scene
/// </summary>
public class DamagePanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/DamagePanel";

    public GameObject script;

    public DamagePanel() :
        base(new UIType(path))
    {
    }

    public override void OnEnter()
    {
        ColorBlock cb = new ColorBlock();
        // cb.normalColor = UnityEngine.Color.green;
        UITool
            .GetOrAddComponentInChildren<Button>("BtnBack")
            .onClick
            .AddListener(() =>
            {
                CountDamage.resetPanel();
                PanelManager.Pop();
            });

        UITool
            .GetOrAddComponentInChildren<TMP_InputField>("InputField1")
            .onValueChanged
            .AddListener((s) =>
            {
                Debug.Log(1);

                // UITool
                //     .GetOrAddComponentInChildren<TMP_InputField>("InputField1")
                //     .GetComponent<TMP_Text>()
                //     .text = "";
                int n = System.Int32.Parse(s);
                int m = ObjectRefresh.GetNumOfBrokenBottles();
                Debug.Log("n==" + n + " m==" + m);
                if (n == m)
                {
                    var cb = UITool
                        .GetOrAddComponentInChildren
                        <Image>("InputField1")
                        .color = UnityEngine.Color.green;
                    cb = UnityEngine.Color.green;
                }
            });

        UITool
            .GetOrAddComponentInChildren<TMP_InputField>("InputField2")
            .onValueChanged
            .AddListener((s) =>
            {
                int n = System.Int32.Parse(s);
                int m = ObjectRefresh.GetNumOfBrokenCreams();
                if (n == m)
                {
                    var cb = UITool
                        .GetOrAddComponentInChildren
                        <Image>("InputField2")
                        .color = UnityEngine.Color.green;
                    cb = UnityEngine.Color.green;

                }
            });

        UITool
            .GetOrAddComponentInChildren<TMP_InputField>("InputField3")
            .onValueChanged
            .AddListener((s) =>
            {
                int n = System.Int32.Parse(s);
                int m = ObjectRefresh.GetNumOfBrokenBuckets();
                if (n == m)
                {
                    var cb = UITool
                        .GetOrAddComponentInChildren
                        <Image>("InputField3")
                        .color = UnityEngine.Color.green;
                    cb = UnityEngine.Color.green;

                }
            });
        UITool
            .GetOrAddComponentInChildren<TMP_InputField>("InputField4")
            .onValueChanged
            .AddListener((s) =>
            {
                int n = System.Int32.Parse(s);
                int m = ObjectRefresh.GetNumOfBrokenPaperBags();
                if (n == m)
                {
                    var cb = UITool
                        .GetOrAddComponentInChildren
                        <Image>("InputField4")
                        .color = UnityEngine.Color.green;
                    cb = UnityEngine.Color.green;

                }
            });
        UITool
            .GetOrAddComponentInChildren<TMP_InputField>("InputField5")
            .onValueChanged
            .AddListener((s) =>
            {
                int n = System.Int32.Parse(s);
                int m = ObjectRefresh.GetNumOfBrokenPaperRolls();
                if (n == m)
                {
                    var cb = UITool
                        .GetOrAddComponentInChildren
                        <Image>("InputField5")
                        .color = UnityEngine.Color.green;
                    cb = UnityEngine.Color.green;

                }
            });
        UITool
            .GetOrAddComponentInChildren<TMP_InputField>("InputField6")
            .onValueChanged
            .AddListener((s) =>
            {
                int n = System.Int32.Parse(s);
                int m = ObjectRefresh.GetNumOfBrokenBoxes();
                if (n == m)
                {
                    var cb = UITool
                        .GetOrAddComponentInChildren
                        <Image>("InputField6")
                        .color = UnityEngine.Color.green;
                    cb = UnityEngine.Color.green;

                }
            });
    }
}
