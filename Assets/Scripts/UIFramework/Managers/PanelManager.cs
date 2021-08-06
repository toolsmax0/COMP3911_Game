using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Panel manager, using a stack to store the UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// A stack that stores UI panels
    /// </summary>
    private Stack<BasePanel> stackPanel;
    /// <summary>
    /// The UI manager
    /// </summary>
    private UIManager uIManager;
    private BasePanel panel;

    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uIManager = new UIManager();
    }

    /// <summary>
    /// UI push operation, which displays a panel
    /// </summary>
    /// <param name="nextPanel">The panel to display</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }
        stackPanel.Push(nextPanel);
        GameObject panelGo = uIManager.GetSingleUI(nextPanel.UIType);
        nextPanel.Initialize(new UITool(panelGo));
        nextPanel.Initialize(this);
        nextPanel.Initialize(uIManager);
        nextPanel.OnEnter();
    }

    /// <summary>
    /// Perform an exit operation of the panel, which executes the panel's OnExit method
    /// </summary>
    public void Pop()
    {
        if (stackPanel.Count > 0)
            stackPanel.Pop().OnExit();
        if (stackPanel.Count > 0)
            stackPanel.Peek().OnResume();
    }

    /// <summary>
    /// Execute OnExit() for all panels
    /// </summary>
    public void PopAll()
    {
        while (stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
    }
}
