using Godot;
using System;

public partial class TowerArea : Area2D
{
    [Export]
    private Camera2D camera;
    [Export]
    private PlayerMove player;
    [Export]
    private Vector2 TowerPosition;
    private bool isInTown;
    public override void _Ready()
    {
        base._Ready();
        AreaEntered += OnPlayerEnter;
        AreaExited += OnPlayerExit;
    }

    private void OnPlayerExit(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            isInTown = false;
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (isInTown)
        {
            if (Input.IsActionJustPressed("OnChose"))
            {
                if (BagFlowUi.Instance.items.Contains(false))
                    return;
                player.isEnterTown = true;
                player.Position = TowerPosition;
                camera.LimitTop = -100000;
            }
        }
    }
    private void OnPlayerEnter(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            isInTown = true;
        }
    }
}
