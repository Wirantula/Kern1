using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMOwner //voorbeeld interactie met statemachine
{
    EnvoirmentStateOne State1;
    StateMachine voorbeeldMachine;
    Dictionary<System.Type, State> list;
    void Start()
    {
        State1 = new EnvoirmentStateOne(); //create states 
        list.Add(typeof(EnvoirmentStateOne), State1);
        voorbeeldMachine = new StateMachine(list); //create statemachine
        voorbeeldMachine.OnStart(State1);            //parse states to machine
        
    }
    void FixedUpdate() //50 ticks a sec
    {
        if(Input.GetKey(KeyCode.A) == true)
        {
            voorbeeldMachine.OnUpdate();                 //update for state machine
        }
       
    }
}
