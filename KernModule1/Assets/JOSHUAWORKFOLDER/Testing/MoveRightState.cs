using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightState : ICommand
{

    //public IState RunState(Player player)
    //{
    //    RunMoveRight(player);
    //    return player.idleState;
    //}

    public void RunMoveRight(Player player)
    {
        player._playerPrefab.transform.Translate(Vector3.right * 5f * Time.deltaTime, Space.World);
    }

    public void Execute(Player player)
    {
        RunMoveRight(player);
    }
}
