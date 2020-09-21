using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftState : ICommand
{

    //public IState RunState(Player player)
    //{
    //    RunMoveLeft(player);
    //    return player.idleState;
    //}

    public void RunMoveLeft(Player player)
    {
        player.playerPrefab.transform.Translate(Vector3.left * 5f * Time.deltaTime, Space.World);
    }

    public void Execute(Player player)
    {
        RunMoveLeft(player);
    }
}
