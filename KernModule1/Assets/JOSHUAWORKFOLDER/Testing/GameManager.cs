using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _playerPrefab;

    Action playerGotHitAction;

    //initializing game
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        //instiate player script en prefab

        _playerPrefab.transform.position = new Vector3(0, 0, 0);
        GameObject playerPrefab = Instantiate(_playerPrefab, transform);
        Player p = new Player(playerPrefab);
        EventManager.InvokeEvent(EventType.ON_STARTUP_TICK);

        playerGotHitAction += playerDead;
        EventManager.AddListener(EventType.ON_PLAYER_DEATH, playerGotHitAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fixed update for time dependend actions
    private void FixedUpdate()
    {

        //Creert update tick met event

        EventManager.InvokeEvent(EventType.ON_UPDATE_TICK);
    }

    private void playerDead()
    {
        //add code for player being hit or dead
        Debug.Log("you died, game over");
        //make the game return
    }

}