using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State currentstate;
    protected int index = 0;
    private Dictionary<System.Type, State> states = new Dictionary<System.Type, State>(); //list of availible states

    public StateMachine(Dictionary<System.Type, State> list) //constructer for state machine
    {
        //geef states mee aan de statemachine 
        //maak een instance aan, run update vanuit monobehavior
        //  this.owner = owner;
        states = list;
    }

    public void OnStart(State state) //init a state
    {      
        currentstate = states[state.GetType()]; //assign given state as first state
        currentstate.OnEnter();
    }
    public void OnUpdate() //get update method from a state
    {
        if (currentstate?.OnUpdate() == false)
        {
            currentstate = states[currentstate.givenextstate()];
            Debug.Log("aaahh wiep");
        }
    }
    public void AddState(State state)
    {
        states.Add(state.GetType(), state); //putting state in dictonary
        Debug.Log(state + " added to " + states.ToString());
    }

}

