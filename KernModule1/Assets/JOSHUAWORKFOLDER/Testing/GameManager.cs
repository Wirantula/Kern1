using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;

    //initializing game
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //instiate player script en prefab
        prefab.transform.position = new Vector3(0, 0, 0);
        GameObject playerPrefab = Instantiate(prefab, transform);
        Player p = new Player(playerPrefab);

    }

    // Update is called once per frame
    void Update()
    {
        //Creert update tick met event
        EventManager.InvokeEvent(EventType.ON_UPDATE_TICK);
    }

    //fixed update for time dependend actions
    private void FixedUpdate()
    {

    }
}