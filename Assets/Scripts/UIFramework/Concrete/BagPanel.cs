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
        //disable first person look

        // Time.timeScale = 1f;
        // Camera.main.GetComponent<FirstPersonLook>().enabled = true;
        // Cursor.lockState = CursorLockMode.Locked;

        // UITool.GetOrAddComponentInChildren<Button>("BtnBack").onClick.AddListener(() =>
        // {
        //     GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        //     Pop();
        // });
    }
    // public override void OnResume()
    // {
    //     base.OnResume();
    //     //disable first person look
    //     Time.timeScale = 1f;
    //     Camera.main.GetComponent<FirstPersonLook>().enabled = true;
    //     Cursor.lockState = CursorLockMode.Locked;
    // }
}
