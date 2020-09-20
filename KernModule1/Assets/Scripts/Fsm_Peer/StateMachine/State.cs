using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public abstract class State
{
    //does a state need a constructor?
    //what would u give an abstract class?
    //public State(StateMachine owner) 
    //{
    //    this.owner = owner;
    //}
    public  StateMachine owner;
    public abstract void OnEnter();
    public abstract bool OnUpdate();

    public delegate bool Isfinished();
    public Isfinished status;

    public abstract Type givenextstate();
}
