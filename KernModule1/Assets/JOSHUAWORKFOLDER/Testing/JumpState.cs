using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    public IState RunState(Player player)
    {
        RunJump(player);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    return player.jumpState;
        //}
        //else 
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
    }

    public void RunJump(Player player)
    {
        //if (player.jumpCoolDown > 0)
        //{
        //    player.jumpCoolDown -= 0.2f;
        //}
        //else 
        if(player.jumpCoolDown <= 0)
        {
            player.playerPrefab.transform.position += new Vector3(0, 5f, 0);
            player.jumpCoolDown = 10f;
        }
        
    }
}
