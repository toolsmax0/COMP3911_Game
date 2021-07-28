using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Moving
}

public class NPCParameter
{
    public float speed = 1.0f;
    public Transform destination;

    public Animator animator;

}

public class FSM : MonoBehaviour
{
    // Start is called before the first frame update

    private IState _currentState;
    private Dictionary<StateType, IState> _states = new Dictionary<StateType, IState>();

    public NPCParameter npcParameter = new NPCParameter();
    void Start()
    {
        _states.Add(StateType.Idle, new IdleState(this, npcParameter));
        _states.Add(StateType.Moving, new MovingState(this, npcParameter));
        //set init state to idle
        ChangeState(StateType.Idle);

        this.npcParameter.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnUpdate();
        }
    }

    public void ChangeState(StateType stateType)
    {
        if (_currentState != null)
        {
            _currentState.OnExit();
        }
        this._currentState = _states[stateType];
        this._currentState.OnEnter();
    }
}
