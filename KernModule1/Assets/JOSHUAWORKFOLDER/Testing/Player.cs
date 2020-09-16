using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player
{
    public Action updateActions;
    public Action setupActions;
    public GameObject playerPrefab;
    public IdleState idleState = new IdleState();
    public JumpState jumpState = new JumpState();
    public MoveLeftState moveLeftState = new MoveLeftState();
    public MoveRightState moveRightState = new MoveRightState();
    public float jumpCoolDown = 10f;

    private IState currentState;

    public Player(GameObject prefab)
    {
        playerPrefab = prefab;
        updateActions += Move;
        setupActions += Init;
        EventManager.AddListener(EventType.ON_UPDATE_TICK, updateActions);
        EventManager.AddListener(EventType.ON_STARTUP_TICK, setupActions);
    }

    public void Init()
    {
        currentState = idleState;
    }

    public void Move()
    {
        currentState = currentState.RunState(this);
        if (jumpCoolDown > 0)
        {
            jumpCoolDown -= 0.25f;
        }
    }
}