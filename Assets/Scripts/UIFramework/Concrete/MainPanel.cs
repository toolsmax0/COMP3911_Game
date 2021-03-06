using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main Main panel of the scene
/// </summary>
public class MainPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MainPanel";

    public MainPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        //disable first person look
        Time.timeScale = 1f;
        Camera.main.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        // UITool.GetOrAddComponentInChildren<Button>("BtnQuit").onClick.AddListener(() =>
        // {
        //     GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        //     Pop();
        // });
        // UITool.GetOrAddComponentInChildren<Button>("BtnMsg").onClick.AddListener(() =>
        // {
        //     Push(new TaskPanel());
        // });
        // UITool.GetOrAddComponentInChildren<Button>("BtnSetting").onClick.AddListener(() =>
        // {
        //     Push(new SettingPanel());
        // });
    }
    public override void OnResume()
    {
        base.OnResume();
        //disable first person look
        Time.timeScale = 1f;
        Camera.main.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
