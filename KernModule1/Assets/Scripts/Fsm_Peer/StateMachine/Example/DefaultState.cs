using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Timers;
using System;

public class DefaultState : State
{
    // protected StateMachine owner;
   //  public event EventHandler Tick;
    public DefaultState(StateMachine owner)
    {
        this.owner = owner;
    }
public void init(StateMachine owner)
    {
        this.owner = owner;
    }

    public override void OnEnter()
    {

    }
    public override bool OnUpdate()
    {
        Debug.Log("Update started");
        //  InitTimer();
        return true;

    }
    public override Type givenextstate()
    {
        return typeof(EnvoirmentStateTwo);
    }
}
