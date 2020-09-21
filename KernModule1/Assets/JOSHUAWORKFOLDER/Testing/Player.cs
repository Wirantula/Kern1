using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player
{

    public Action _updateActions;
    public Action _setupActions;
    public GameObject _playerPrefab;

    /* I have thought about making the states a singleton
     * making them create a static instance of them selves
     * but I also figured this would miss use the singleton pattern
     */

    public IdleState _idleState = new IdleState();
    public JumpState _jumpState = new JumpState();
    public MoveLeftState _moveLeftState = new MoveLeftState();
    public MoveRightState _moveRightState = new MoveRightState();
    public float _jumpCoolDown = 10f;
    //I tried creating a seperate fsm but it would mostly result in more complex code
    //for something that can be done slightly less clean but a lot easier for the system that it is
    //public FiniteStateMachine _fsm;

    
    private float _rayCastTimer = 20f;
    private IState _currentState;
    private PlayerInputHandler _playerInput;
    private int _lives;

    public Player(GameObject prefab)
    {
        _playerPrefab = prefab;
        _updateActions += PlayerUpdate;
        _setupActions += Init;
        EventManager.AddListener(EventType.ON_UPDATE_TICK, _updateActions);
        EventManager.AddListener(EventType.ON_STARTUP_TICK, _setupActions);
    }

    public void Init()
    {
        _lives = 3;
        _currentState = _idleState;
        _playerInput = new PlayerInputHandler(_moveLeftState, _moveRightState, _jumpState, this);
        //seperate fsm removed due to not necessary complexity
        //_fsm = new FiniteStateMachine(this);
        //_fsm.AddState(new JumpState());
        //_fsm.AddState(new MoveLeftState());
        //_fsm.AddState(new MoveRightState());

    }

    public void PlayerUpdate()
    {
        _playerInput.HandleInput();
        if (_jumpCoolDown > 0)
        {
            _jumpCoolDown -= 0.25f;
        }

        if(_rayCastTimer <= 0)
        {
            ExecuteRaycast();
        }
        else if (_rayCastTimer > 0)
        {
            _rayCastTimer -= 0.25f;
        }
    }

    public void ExecuteRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(_playerPrefab.transform.position, _playerPrefab.transform.up, out hit))
        {
            if(hit.collider.transform.position.y - _playerPrefab.transform.position.y <= 2.5f)
            {
                _lives--;
                Debug.Log("You have lost a life");
                if (_lives <= 0)
                {
                    EventManager.InvokeEvent(EventType.ON_PLAYER_DEATH);
                }
            }
        }
        _rayCastTimer = 20f;
    }

}