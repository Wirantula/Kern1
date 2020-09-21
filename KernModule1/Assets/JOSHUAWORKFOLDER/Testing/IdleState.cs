using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public IState RunState(Player player)
    {
        return player.idleState;
    }
}
