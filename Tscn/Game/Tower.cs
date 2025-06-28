using Godot;
using System;
using System.Net.NetworkInformation;

public partial class Tower : Node2D
{
    [Export]
    private Area2D area;
    [Export]
    private Area2D areaWin;
    [Export]
    private PlayerMove player;
    [Export]
    private Vector2 TowerPosition;
    private bool isInTown;
    public override void _Ready()
    {
        base._Ready();
        if (area != null)
            area.AreaEntered += OnPlayerEnter;
        if (areaWin != null)
            areaWin.AreaEntered += OnWinPlayerEnter;
    }

    private void OnPlayerEnter(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            player.Position = TowerPosition;
        }
    }
    private void OnWinPlayerEnter(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            if (NetManager.Instance.netServe != null)
            {
                if (NetManager.Instance.Multiplayer.IsServer())
                {
                    GameManager.Instance.RpcId(NetManager.Instance.playerId, "ServeFinishGame");
                }
                else
                {
                    GameManager.Instance.RpcId(1, "ClientFinishGame");
                }
            }
            else
            {
                GD.Print("Win");
            }
        }
    }
}
