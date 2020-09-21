using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler
{
    private ICommand ACommand;
    private ICommand DCommand;
    private ICommand SpaceCommand;
    private Player player;

    public PlayerInputHandler(ICommand aCommand, ICommand dCommand, ICommand spaceCommand, Player player)
    {
        ACommand = aCommand;
        DCommand = dCommand;
        SpaceCommand = spaceCommand;
        this.player = player;
    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.A)) { ACommand.Execute(player); }
        if (Input.GetKey(KeyCode.D)) { DCommand.Execute(player); }
        if (Input.GetKeyDown(KeyCode.Space)) { SpaceCommand.Execute(player); }
    }
}
