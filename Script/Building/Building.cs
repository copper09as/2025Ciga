using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Building : Node2D
{
    [Export]
    private Timer timer;
    [Export]
    private Area2D area;
    private bool isFinish = false;
    [Export]
    private int id;
    [Export]
    private Godot.Collections.Array<int> buildings;
    [Export]
    private ProgressBar progress;
    [Export]
    private AppearShader appearShader;
    
    private bool isChose;
    private bool inStay;
    public override void _Ready()
    {
        base._Ready();
        area.AreaEntered += onAreaEnter;
        area.AreaExited += onAreaExit;
        timer.Timeout += timerOut;
        SignalEventCenter.Instance.RegisterEvent(this, MethodName.FinishChose);
    }
    private void timerOut()
    {
        var wheel = ResManager.Instance.CreateInstance<Wheel>("res://Tscn/Ui/wheel.tscn", UiContain.instance, "Wheel");
        wheel.Position = wheel.Position = new Vector2(PlayerMove.Instance.Position.X-1000, PlayerMove.Instance.Position.Y-600);
        wheel.rightId = id;
        wheel.buildings = buildings;
        wheel.Init();
    }
    public void FinishChose(int id)
    {
        if (id == this.id)
        {
            StartAppear();
            isFinish = true;
            progress.Hide();
            BagFlowUi.Instance.items[0] = true;
        }
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (isFinish)
            return;
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
    public void StartAppear()
    {
        this.Show();
        appearShader.Show = true;
    }
}
