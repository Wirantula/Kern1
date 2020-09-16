using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftState : IState
{
    public IState RunState(Player player)
    {
        RunMoveLeft(player);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return player.jumpState;
        }
        else if (Input.GetKey(KeyCode.A))
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

    public void RunMoveLeft(Player player)
    {
        //if (player.jumpCoolDown > 0)
        //{
        //    player.jumpCoolDown -= 0.2f;
        //}
        player.playerPrefab.transform.Translate(Vector3.left * 5f * Time.deltaTime, Space.World);
    }
}
