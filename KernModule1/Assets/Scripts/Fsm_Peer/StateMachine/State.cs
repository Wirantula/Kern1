﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    //public State(StateMachine owner)
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