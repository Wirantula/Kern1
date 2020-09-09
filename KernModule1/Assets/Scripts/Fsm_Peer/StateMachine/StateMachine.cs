using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State currentstate; 
    private Dictionary<System.Type, State> states = new Dictionary<System.Type, State>(); //list of availible states

    public void OnStart(DefaultState state) //init a state
    {
        AddState(state);
        currentstate = states[state.GetType()];
    }
    public void OnUpdate() //get update method from a state
    {
        currentstate?.OnUpdate();
    }
    public void AddState(State state)
    {
        states.Add(state.GetType(), state); //putting state in dictonary
        Debug.Log(state + " added to " + states);
    }
}

