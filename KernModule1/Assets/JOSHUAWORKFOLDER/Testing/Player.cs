﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player
{

    public Action updateActions;
    public Action setupActions;
    public GameObject playerPrefab;

    /* I have though about making the states a singleton
     * making them create a static instance of them selves
     * but I also figured this would miss use the singleton pattern
     */

    public IdleState idleState = new IdleState();
    public JumpState jumpState = new JumpState();
    public MoveLeftState moveLeftState = new MoveLeftState();
    public MoveRightState moveRightState = new MoveRightState();
    public float jumpCoolDown = 10f;
    public float rayCastTimer = 20f;

    //I tried creating a seperate fsm but it would mostly result in more complex code
    //for something that can be done slightly less clean but a lot easier for the system that it is
    //public FiniteStateMachine _fsm;

    private IState currentState;

    public Player(GameObject prefab)
    {
        playerPrefab = prefab;
        updateActions += PlayerUpdate;
        setupActions += Init;
        EventManager.AddListener(EventType.ON_UPDATE_TICK, updateActions);
        EventManager.AddListener(EventType.ON_STARTUP_TICK, setupActions);
    }

    public void Init()
    {
        currentState = idleState;

        //seperate fsm removed due to not necessary complexity
        //_fsm = new FiniteStateMachine(this);
        //_fsm.AddState(new JumpState());
        //_fsm.AddState(new MoveLeftState());
        //_fsm.AddState(new MoveRightState());

    }

    public void PlayerUpdate()
    {
        currentState = currentState.RunState(this);
        if (jumpCoolDown > 0)
        {
            jumpCoolDown -= 0.25f;
        }

        if(rayCastTimer <= 0)
        {
            ExecuteRaycast();
        }
        else if (rayCastTimer > 0)
        {
            rayCastTimer -= 0.25f;
        }
    }

    public void ExecuteRaycast()
    {
        Debug.Log("i got exec");
        RaycastHit hit;
        if(Physics.Raycast(playerPrefab.transform.position, playerPrefab.transform.up, out hit))
        {
            Debug.Log("fired ray");
            if(hit.collider.transform.position.y - playerPrefab.transform.position.y <= 2.5f)
            {
                Debug.DrawRay(playerPrefab.transform.position, playerPrefab.transform.up, Color.black);
                Debug.Log("I found object");
                EventManager.InvokeEvent(EventType.ON_HIT);
            }
        }
        rayCastTimer = 20f;
    }

}