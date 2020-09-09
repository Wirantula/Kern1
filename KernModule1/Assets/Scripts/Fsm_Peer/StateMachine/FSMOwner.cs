using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMOwner : MonoBehaviour
{
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
    }
}
