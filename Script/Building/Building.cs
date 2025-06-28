using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Building : Sprite2D
{
    [Export]
    private Timer timer;
    [Export]
    private Area2D area;
    [Export]
    private Godot.Collections.Array<int> items;
    [Export]
    private ProgressBar progress;
    private bool isChose;
    private bool inStay;
    public override void _Ready()
    {
        base._Ready();
        area.AreaEntered += onAreaEnter;
        area.AreaExited += onAreaExit;
        timer.Timeout += timerOut;
    }
    private void timerOut()
    {
        var wheel = ResManager.Instance.CreateInstance<Wheel>("res://Tscn/Ui/wheel.tscn", UiContain.instance, "Wheel");
        wheel.Position = Vector2.Zero;
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!inStay)
            return;
        if (Input.IsActionJustPressed("OnChose"))
        {
            timer.Start();
        }
        if (Input.IsActionJustReleased("OnChose"))
        {
            timer.Stop();
        }
        progress.Value = 100 * (timer.TimeLeft / timer.WaitTime);
    }

    private void onAreaExit(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            inStay = false;
            GD.Print(area.Name + "退出");
        }
    }
    private void onAreaEnter(Area2D area)
    {
        if (area.IsInGroup("Player"))
        {
            inStay = true;
            GD.Print(area.Name + "进入");
        }
    }
}
