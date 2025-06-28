using Godot;
using System;

public partial class WheelSelect : ColorRect
{
    private static bool inChose = false;
    private static int selectId;
    [Export]
    public int id;
    [Export]
    private Color transColor;
    [Export]
    private Color initColor;
    [Export]
    private Wheel wheel;
    public override void _Ready()
    {
        base._Ready();
        initColor = this.Color;
        MouseEntered += OnMouseEnter;
        MouseExited += OnMouseExit;
        
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionPressed("Confirm") && selectId == id)
        {
            FinishChose(id);
        }
    }
    public void FinishChose(int id)
    {
        GD.Print(this.id);
        selectId = -1;
        SignalEventCenter.Instance.TriggerEvent("FinishChose",id);
        wheel.Delete();
    }
    public void OnMouseExit()
    {
        inChose = false;
        var tween = GetTree().CreateTween();
        selectId = -1;
        tween.TweenProperty(this, "modulate", initColor, 0.5);
    }
    public void OnMouseEnter()
    {
        if (inChose)
            return;
        inChose = true;
        selectId = id;
        var tween = GetTree().CreateTween();
        tween.TweenProperty(this, "modulate", transColor, 0.5);
    }
}
