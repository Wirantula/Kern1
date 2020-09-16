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

        //Hacky movement, workupon
        //if (Input.GetKey(KeyCode.W))
        //{
        //    playerPrefab.transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    playerPrefab.transform.Translate(Vector3.back * 5f * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    playerPrefab.transform.Translate(Vector3.left * 5f * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    playerPrefab.transform.Translate(Vector3.right * 5f * Time.deltaTime, Space.World);
        //}
    }
}