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
        Player p = new Player(prefab);
        Instantiate(p.playerPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        EventManager.InvokeEvent(EventType.ON_UPDATE_TICK);
    }

    //fixed update for time dependend actions
    private void FixedUpdate()
    {

    }
}
