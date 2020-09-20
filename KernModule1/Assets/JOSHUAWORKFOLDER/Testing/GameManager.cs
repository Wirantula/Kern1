using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    public GameObject spawn;
    ObjectPool voorwerp = new ObjectPool();
    //----------StateMachine Environment---------------\\
    StateMachine Envoirment;
    Dictionary<System.Type, State> list;
    //-------------------------------------------------\\
    private void Awake()
    {
        voorwerp.Pools = new List<ObjectPool.Pool>();
        voorwerp.execution();
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

     public void ObjectPoolCall()
    {
        // ObjectPool.Instance.SpawnFromPool("stalc", new Vector3(CreateRandomBetween(-5, 7), CreateRandomBetween(4, 7), CreateRandomBetween(-1, -2)), new Quaternion(0, 0, 0, 0));
        voorwerp.FillPool(1);
        voorwerp.execution();
        voorwerp.SpawnFromPool("stalc", new Vector3(CreateRandomBetween(-50, 70), CreateRandomBetween(40, 70), CreateRandomBetween(-10, -20)), new Quaternion(0,CreateRandomBetween(-10, -20), 0, 0));
    }
    public void Spawner(GameObject spawn)
    {
        Instantiate(spawn);
    }
    public int CreateRandomBetween(int a, int b)
    {
        int getrandom = Random.Range(a, b);

        return getrandom;
    }
}