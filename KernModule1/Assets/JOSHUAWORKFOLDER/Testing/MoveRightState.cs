using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightState : IState
{

    public IState RunState(Player player)
    {
        RunMoveRight(player);

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

    public void RunMoveRight(Player player)
    {
        player.playerPrefab.transform.Translate(Vector3.right * 5f * Time.deltaTime, Space.World);
    }

}
