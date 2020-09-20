using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Timers;
using System;

public class EnvoirmentStateOne : State
{
    // protected StateMachine owner;
    //  public event EventHandler Tick;

    static int MonoTime = 0;
    int FpsToSec = 50;
    int MonoSeconds = 0;
    int eventtime = 5;
    
    public EnvoirmentStateOne()
    {
      //  this.owner = owner;
    }
    public override void OnEnter()
    {
        //basicly void start()

        /*
         * wat moet de envoirment 1 allemaal doen:
         * - geef de speler 10 seconden tijd voor de volgende
         * - n.o.t.k
         */
    }
    public override bool OnUpdate()
    {
        MonoTime += 1;
        if(MonoTime == FpsToSec)
        {
            Debug.Log(MonoSeconds);
            FpsToSec+=50;
            MonoSeconds++;
        }
        if(MonoSeconds == eventtime)
        {
            Debug.Log("end of state");
           return false;
        }
        return true;
    }
    public override Type givenextstate()
    {
     return typeof(EnvoirmentStateTwo);
    }

}
