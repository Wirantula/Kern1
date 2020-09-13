using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
<<<<<<< HEAD
    //does a state need a constructor?
    //what would u give an abstract class?
    //public State(StateMachine owner) 
=======
    //public State(StateMachine owner)
>>>>>>> master
    //{
    //    this.owner = owner;
    //}
    protected StateMachine owner;
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    public delegate bool Isfinished();
    public Isfinished status;
}
