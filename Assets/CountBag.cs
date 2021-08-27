using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBag : MonoBehaviour
{
    private static bool panelOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (!panelOn)
            GameRoot.Instance.Push(new BagPanel());
        panelOn = true;
    }

    public static void resetPanel()
    {
        panelOn = false;
    }
}
