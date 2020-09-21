using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]

    //private GameObject prefab;
    //public GameObject stalac;
    private GameObject _playerPrefab;
    Action playerGotHitAction;

    //----------StateMachine Environment---------------\\
    StateMachine Envoirment;
    Dictionary<System.Type, State> StateList;
    //-------------------------------------------------\\
    [System.Serializable]
    
    public class Pool
    {
        public string tag;
        public GameObject stalactiet;
        public int Size = 15;
    }
    public List<Pool> Pools;
    private void Awake()
    {

    }

    void Start()
    {

        //StateList = new Dictionary<System.Type, State>();
        //instantiate player en prefab
        //prefab.transform.position = new Vector3(0, 0, 0);
        //GameObject playerPrefab = Instantiate(prefab, transform);


        //instiate player script en prefab

        _playerPrefab.transform.position = new Vector3(0, 0, 0);
        GameObject playerPrefab = Instantiate(_playerPrefab, transform);

        Player p = new Player(playerPrefab);

        EventManager.InvokeEvent(EventType.ON_STARTUP_TICK);
        // EventManager.AddListener(EventType.ON_STARTUP_TICK,Update); //example listner statemachine (adds update as eventlistner )

        // Envoirment
        EnvoirmentStateOne State1 = new EnvoirmentStateOne(); //create state 
        StateList.Add(typeof(EnvoirmentStateOne), State1);
        EnvoirmentStateTwo State2 = new EnvoirmentStateTwo();
        StateList.Add(typeof(EnvoirmentStateTwo), State2);
        Envoirment = new StateMachine(StateList); //create statemachine
        Envoirment.OnStart(State1);


        // EventManager.AddListener(EventType.ON_STARTUP_TICK, )

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
        Envoirment.OnUpdate();                 //update for Envoirment

    }

    public void Spawner(GameObject spawn)
    {
        Instantiate(spawn);
       // stalac = new GameObject();
       // Instantiate(stalac);
        DeadOnCollision instance = new DeadOnCollision();
        instance.init(stalac);
        instance.LocalUpdate(GameObject.FindGameObjectsWithTag("colidable"));
    }


    private void playerDead()
    {
        //add code for player being hit or dead
        Debug.Log("you died, game over");
        //make the game return
    }

}