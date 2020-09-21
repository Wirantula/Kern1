using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Timers;
using System;

public class EnvoirmentStateTwo : State
{
    // protected StateMachine owner;
    //  public event EventHandler Tick;

    static int localTime = 0;
    static int MonoTime = 0;
    int FpsToSec = 50;
    int MonoSeconds = 0;
    int eventtime = 10;

    GameManager origin;
    ObjectPool stalacpool = new ObjectPool();

    public EnvoirmentStateTwo()
    {
     //   this.owner = owner;
    }
    public override void OnEnter()
    {
        //basicly void start()

        /*
         * wat moet de envoirment allemaal doen:
         * - stalactieten laten vallen
         * - camera shake * cave status(gebaseerd op tijd)
          */
        // LevelActiveTimer(); //starts the timer of level duration
        //stalctieten.awake();
        //stalctieten.execution();

        //stalacpool.Pools = new List<ObjectPool.Pool>();
        //stalacpool.FillPool(1, "stalactietPrefab(Clone)");
        Debug.Log("entering stage 2");
         origin = GameObject.Find("Scriptholder").GetComponent<GameManager>();

        stalacpool.execution(origin.Pools,origin.stalac,origin);
    }
    public override bool OnUpdate()
    {
        // stalctieten.SpawnFromPool("stalc", new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        MonoTime += 1;
        if(MonoTime == FpsToSec)
        {
            Debug.Log(MonoSeconds);
            FpsToSec+=50;
            MonoSeconds++;

            //spawn stalactieten elke seconden
            stalacpool.SpawnFromPool(origin.stalac.name, new Vector3(RND(0, 70), RND(0, 70), RND(-10, -20)), new Quaternion(0, RND(-10, -20), 0, 0));
        }
        if (MonoSeconds == eventtime)
        {
            //TODO: add camera shake
           // eventtime += 10; //next event
            Debug.Log("Changing state");
            return false;
        }
        return true;
    }

    public void LevelActiveTimer() //creates a timer that is independend of monobehavior update
    {
        Timer timer1 = new Timer
        {
            Interval = 1000
        };
        // timer1 = new System.Timers.Timer(1000); for Pc Time
        timer1 = new Timer();
        timer1.Elapsed += OnTimerEvent; //happends every second
        timer1.Enabled = true;
    }

    public static void OnTimerEvent(object source, EventArgs e)
    {
        localTime += 1;
        //System.Random a = new System.Random();
       // Debug.Log(localTime);
    }

    public override Type givenextstate()
    {
        return typeof(EnvoirmentStateOne);
    }

    public int RND(int a, int b)
    {
        int getrandom = UnityEngine.Random.Range(a, b);

        return getrandom;
    }
}
