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
            GetChild(0).QueueFree();
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
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Instance != this || (NetManager.Instance.playerId ==-1&&NetManager.Instance.Multiplayer.IsServer()))
        {
            return;
        }
        if (NetManager.Instance.Multiplayer.IsServer())
        {
            RpcId(NetManager.Instance.playerId, MethodName.ServeUpdatePos, PlayerMove.Instance.Position);
        }
        else
        {
            RpcId(1, MethodName.ClientUpdatePos, PlayerMove.Instance.Position);
        }
    }

    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void ClientUpdatePos(Vector2 pos)
    {
        var s = (Sprite2D)GetChild(0);
        s.Position = pos;
    }
    [Rpc(MultiplayerApi.RpcMode.Authority)]
    public void ServeUpdatePos(Vector2 pos)
    {
        var s = (Sprite2D)GetChild(0);
        s.Position = pos;
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
