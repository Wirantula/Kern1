using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : ICommand
{

    //public IState RunState(Player player)
    //{
    //    RunJump(player);
    //    return player.idleState;
    //}

    public void RunJump(Player player)
    {
        if(player._jumpCoolDown <= 0)
        {
            player._playerPrefab.transform.position += new Vector3(0, 5f, 0);
            player._jumpCoolDown = 10f;
        }
    }

    public void Execute(Player player)
    {
        RunJump(player);
    }

}
