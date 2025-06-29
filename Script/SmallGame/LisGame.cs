using Godot;
using System;

public partial class LisGame : Node2D
{
    [Export]
    private Label diagLabel;
    [Export(PropertyHint.MultilineText)]
    private Godot.Collections.Array<String> digs;
    [Export]
    private Area2D area;
    [Export]
    private Godot.Collections.Array<Vector2> pos;
    private bool playerStay;
    private int count = 0;
    public override void _Ready()
    {
        base._Ready();
        count = 0;
        area.AreaEntered += OnPlayerEnter;
        area.AreaExited += OnPlayerExit;
        this.Position = pos[3];
        area.Position = pos[0];
        diagLabel.Text = digs[0];
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (playerStay)
        {
            if (Input.IsActionJustPressed("OnChose"))
            {
                GD.Print(count);
                if (count < 2)
                {
                    count += 1;
                    area.Position = pos[count];
                    diagLabel.Text = digs[count];
                    SmallGameManager.Instance.FinishSmallGame();
                    GD.Print("听声音游戏结束");
                }
                else
                {
                    this.QueueFree();
                }
            }
        }
        if (Input.IsActionPressed("Confirm"))
        {
            if (playerStay)
            {
                PlayerMove.Instance.PlaySound(false, 24);
            }
            else
            {
                PlayerMove.Instance.PlaySound(false, -10);
            }
        }

    }


    private void OnPlayerExit(Area2D area)
    {
        GD.Print("玩家离开小游戏区域");
        playerStay = false;
    }


    private void OnPlayerEnter(Area2D area)
    {
        GD.Print("玩家进入小游戏区域");
        playerStay = true;
    }

}
