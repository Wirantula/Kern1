using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler
{

    private ICommand _aCommand;
    private ICommand _dCommand;
    private ICommand _spaceCommand;
    private Player _player;

    public PlayerInputHandler(ICommand aCommand, ICommand dCommand, ICommand spaceCommand, Player player)
    {
        _aCommand = aCommand;
        _dCommand = dCommand;
        _spaceCommand = spaceCommand;
        this._player = player;
    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.A)) { _aCommand.Execute(_player); }
        if (Input.GetKey(KeyCode.D)) { _dCommand.Execute(_player); }
        if (Input.GetKeyDown(KeyCode.Space)) { _spaceCommand.Execute(_player); }
    }

}
