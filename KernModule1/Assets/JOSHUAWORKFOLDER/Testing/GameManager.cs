using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    //----------StateMachine Environment---------------\\
    StateMachine Envoirment;
    Dictionary<System.Type, State> list;
    //-------------------------------------------------\\
    private void Awake()
    {

    }
    
    void Start()
    {
        list = new Dictionary<System.Type, State>();
        //instantiate player en prefab
        prefab.transform.position = new Vector3(0, 0, 0);
        GameObject playerPrefab = Instantiate(prefab, transform);
        Player p = new Player(playerPrefab);

        EventManager.InvokeEvent(EventType.ON_STARTUP_TICK);        
        // EventManager.AddListener(EventType.ON_STARTUP_TICK,Update); //example listner statemachine (adds update as eventlistner )

        // Envoirment
        EnvoirmentStateOne State1 = new EnvoirmentStateOne(); //create state 
        list.Add(typeof(EnvoirmentStateOne), State1);
        EnvoirmentStateTwo State2 = new EnvoirmentStateTwo(); 
        list.Add(typeof(EnvoirmentStateTwo), State2);
        Envoirment = new StateMachine(list); //create statemachine
        Envoirment.OnStart(State1);
        
       // EventManager.AddListener(EventType.ON_STARTUP_TICK, )
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
}