using Godot;
using System;

public partial class MainInterface : Control
{
    [Export]
    private ProgressBar progressBar;
    [Export]
    private Control loadPanel;
    [Export]
    private TextureButton Startbtn;
    [Export]
    private Timer timer;
    [Export]
    private Timer loadTimer;
    [Export]
    private Color initColor;
    [Export]
    private Color transColor;
    private bool btnState = false;
    public override void _Ready()
    {
        base._Ready();
        Startbtn.ButtonDown += OnStartBtnPress;
        shakeBtn();
        timer.Timeout += shakeBtn;
        loadTimer.Timeout += onLoad;
    }

    private void onLoad()
    {
        SceneChangeManager.Instance.ChangeScene("res://Tscn/Game/main_game.tscn");
    }
    private void shakeBtn()
    {
        if (btnState)
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(Startbtn, "modulate", initColor, 2);
        }
        else
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(Startbtn, "modulate", transColor, 2);
        }
        btnState = !btnState;
        
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionJustPressed("OnChose"))
        {
            OnStartBtnPress();
        }
        progressBar.Value = 100 * (1 - loadTimer.TimeLeft / loadTimer.WaitTime);
    }
    private void OnStartBtnPress()
    {
        loadTimer.Start();
        loadPanel.Show();
    }
}
