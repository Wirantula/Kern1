using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player
{
    public Action updateActions;
    public GameObject playerPrefab;
    
    public Player(GameObject prefab)
    {
        playerPrefab = prefab;
        updateActions += Move;
        EventManager.AddListener(EventType.ON_UPDATE_TICK, updateActions);
    }

    public void Move()
    {
        //do some moves
        Debug.Log("i got executed");
    }
}
