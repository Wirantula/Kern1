using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

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
        EventManager.InvokeEvent(EventType.ON_STARTUP_TICK);

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
}