﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMOwner : MonoBehaviour
{
<<<<<<< HEAD
    EnvoirmentIdle State1;
    StateMachine voorbeeldMachine;
    void Start()
    {
        State1 = new EnvoirmentIdle(voorbeeldMachine); //create states 
        voorbeeldMachine = new StateMachine(State1); //create statemachine
        voorbeeldMachine.OnStart(State1);            //parse states to machine
        
    }
    void FixedUpdate() //50 ticks a sec
    {
        if(Input.GetKey(KeyCode.A) == true)
        {
            voorbeeldMachine.OnUpdate();                 //update for state machine
        }
       
=======
    DefaultState State1;
    StateMachine voorbeeldMachine;
    void Start()
    {
        State1 = new DefaultState(voorbeeldMachine);
        voorbeeldMachine = new StateMachine(State1);
        voorbeeldMachine.OnStart(State1);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        voorbeeldMachine.OnUpdate();
>>>>>>> master
    }
}
