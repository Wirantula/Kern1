using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBase 
{

    abstract public float Takedamage (float dmg);
    abstract public float Move();
    abstract public float Attack();



    public ActorBase()
    {

    }
}
