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

        UITool.GetOrAddComponentInChildren<Slider>("JQSlider").value = (float)Settings.jumpQueueProb;
        UITool.GetOrAddComponentInChildren<Slider>("JQSlider").onValueChanged.AddListener((float value) =>
        {
            Settings.jumpQueueProb = value;
            Debug.Log(value);
        });

        UITool.GetOrAddComponentInChildren<Slider>("PaymentSlider").value = (float)Settings.paymentProb;
        UITool.GetOrAddComponentInChildren<Slider>("PaymentSlider").onValueChanged.AddListener((float value) =>
        {
            Settings.paymentProb = value;
            Debug.Log(value);
        });

        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_1").isOn = (Settings.maxNumOfCustomers == 1) ? true : false;
        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_1").onValueChanged.AddListener((bool value) =>
        {
            if (value)
                Settings.maxNumOfCustomers = 1;
        });
        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_2").isOn = (Settings.maxNumOfCustomers == 2) ? true : false;
        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_2").onValueChanged.AddListener((bool value) =>
        {
            if (value)
                Settings.maxNumOfCustomers = 2;
        });
        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_3").isOn = (Settings.maxNumOfCustomers == 3) ? true : false;
        UITool.GetOrAddComponentInChildren<Toggle>("Toggle_3").onValueChanged.AddListener((bool value) =>
        {
            if (value)
                Settings.maxNumOfCustomers = 3;
        });
    }
}
