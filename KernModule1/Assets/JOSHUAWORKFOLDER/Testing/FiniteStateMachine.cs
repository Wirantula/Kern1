using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FiniteStateMachine
{
    public Action updateActions;
    public Action startActions;
    private Player _player;
    private IState currentState;
    private Dictionary<System.Type, IState> states = new Dictionary<System.Type, IState>();

    public FiniteStateMachine(Player player)
    {
        _player = player;
        updateActions += updateActions;
        startActions += Init;
        EventManager.AddListener(EventType.ON_UPDATE_TICK, updateActions);
        EventManager.AddListener(EventType.ON_STARTUP_TICK, startActions);
    }

    public void Init()
    {
        AddState(new IdleState());
        currentState = states[typeof(IdleState)].RunState(_player);
    }

    public void UpdateStates()
    {
        currentState = currentState.RunState(_player);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = states[typeof(JumpState)].RunState(_player);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentState = states[typeof(MoveLeftState)].RunState(_player);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentState = states[typeof(MoveRightState)].RunState(_player);
        }
        else
        {
            currentState = states[typeof(IdleState)].RunState(_player);
        }
    }

    public void AddState(IState state)
    {
        states.Add(state.GetType(), state);
    }
}
