using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public IState RunState(Player player)
    {
        RunIdle(player);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return player.jumpState;
        }
        else
        if (Input.GetKey(KeyCode.A))
        {
            return player.moveLeftState;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return player.moveRightState;
        }
        else
        {
            return player.idleState;
        }
        //return this;
    }

    public void RunIdle(Player player)
    {
        //if(player.jumpCoolDown > 0)
        //{
        //    player.jumpCoolDown -= 0.2f;
        //}
    }
}
