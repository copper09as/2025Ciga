using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Npc : Node2D
{
    [Export]
    private AudioStreamPlayer2D audioStreamPlayer;
    [Export]
    private Label diaLabel;
    [Export]
    private Timer timer;
    [Export(PropertyHint.MultilineText)]
    private int index;
    [Export]
    private Godot.Collections.Array<string> dialogs;
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
    [Export]
    private bool isChose;
    [Export]
    private int item;
    [Export]
    private bool inStay;
    [Export]
    public bool isFinishGame;
    [Export]
    public GameType gameType;
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
        if (SmallGameManager.Instance.isStartSmallGame)
        {
            GD.Print("小游戏未结束");
            return;
        }
        if (!isFinishGame && gameType != GameType.None)
        {
            GD.Print(id.ToString() + "可以开始小游戏");
            SmallGameManager.Instance.CreateSmallGame(this.gameType, this);
        }
        else if (!isFinish && (isFinishGame || gameType == GameType.None))
        {
            var wheel = ResManager.Instance.CreateInstance<Wheel>("res://Tscn/Ui/wheel.tscn", UiContain.instance, "Wheel");
            GD.Print(id.ToString() + "可以开始轮盘");
            wheel.Position = wheel.Position = new Vector2(PlayerMove.Instance.Position.X - 1000, PlayerMove.Instance.Position.Y - 600);
            wheel.rightId = id;
            wheel.buildings = buildings;
            wheel.Init();
        }
        else
        {
            GD.Print("发起对话");
            diaLabel.Show();
            diaLabel.Text = dialogs[index];
            index += 1;
            if (dialogs.Count == index)
            {
                index = 0;
            }
        }
    }
    public void FinishChose(int id)
    {
        if (id == this.id)
        {
            GD.Print(this.id);
            StartAppear();
            isFinish = true;
            progress.Hide();
            if (item != -1)
            {
                BagFlowUi.Instance.items[item] = true;
            }
        }
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
    public void StartAppear()
    {
        this.Show();
        appearShader.Show = true;
    }
}
