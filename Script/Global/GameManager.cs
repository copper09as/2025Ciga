using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public override void _ExitTree()
    {
        base._ExitTree();
        if (Instance == this)
        {
            Instance = null;
        }
    }
    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ClientFinishGame()
    {
        GD.Print("客户端赢了");
    }
    [Rpc(MultiplayerApi.RpcMode.Authority)]
    public void ServeFinishGame()
    {
        GD.Print("服务端赢了");
    }
}
