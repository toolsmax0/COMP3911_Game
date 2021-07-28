using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IdleState : IState
{
    private FSM manager;
    private NPCParameter npcParameter;

    public IdleState(FSM manager, NPCParameter npcParameter)
    {
        this.manager = manager;
        this.npcParameter = npcParameter;
    }
    public void OnEnter()
    {

    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}

public class MovingState : IState
{
    private FSM manager;
    private NPCParameter npcParameter;

    public MovingState(FSM manager, NPCParameter npcParameter)
    {
        this.manager = manager;
        this.npcParameter = npcParameter;
    }
    public void OnEnter()
    {

    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}
