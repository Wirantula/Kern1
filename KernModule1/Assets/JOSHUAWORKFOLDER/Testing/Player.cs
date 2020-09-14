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
        //Hacky movement, workupon
        if (Input.GetKey(KeyCode.W))
        {
            playerPrefab.transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerPrefab.transform.Translate(Vector3.back * 5f * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerPrefab.transform.Translate(Vector3.left * 5f * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerPrefab.transform.Translate(Vector3.right * 5f * Time.deltaTime, Space.World);
        }
    }
}