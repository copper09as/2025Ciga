using Godot;
using System;

public partial class MainInterface : Control
{
    [Export]
    private TextureButton Startbtn;
    public override void _Ready()
    {
        base._Ready();
        Startbtn.ButtonDown += OnStartBtnPress;
    }
   public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionJustPressed("OnChose"))
        {
            OnStartBtnPress();
        }
    }

    private void OnStartBtnPress()
    {
        SceneChangeManager.Instance.ChangeScene("res://Tscn/Game/main_game.tscn");
    }
}
