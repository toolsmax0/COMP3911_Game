using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
            int inputed = System.Int32.Parse(s);

            //todo: please provide interface to get the number of bag in scene
            // int presented = ObjectRefresh.GetNumOfBrokenBottles();
            int presented = ObjectRefresh.GetNumOfBags();
            Debug.Log("n==" + inputed + " m==" + presented);
            if (inputed == presented)
            {
                UITool
                   .GetOrAddComponentInChildren
                   <Image>("InputField1")
                   .color = UnityEngine.Color.green;
            }
            else
            {
                UITool
                .GetOrAddComponentInChildren
                <Image>("InputField1")
                .color = UnityEngine.Color.red;
            }
        });
    }
}
