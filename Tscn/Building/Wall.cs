using Godot;
using System;

public partial class Wall : Area2D
{
    public override void _Ready()
    {
        base._Ready();
        AreaEntered += OnPlayerEnter;
    }

    private void OnPlayerEnter(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            Tower.Instance.playerMove.Position = Tower.Instance.InitPosition;
        }
    }
}
