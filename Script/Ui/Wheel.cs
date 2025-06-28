using Godot;
using System;

public partial class Wheel : Control
{
    private static bool exsist;
    public int rightId = 0;
    [Export]
    private WheelSelect select1;
    [Export]
    private WheelSelect select2;
    [Export]
    private WheelSelect select3;
    [Export]
    private WheelSelect select4;
    public override void _Ready()
    {
        base._Ready();
        if (exsist)
        {
            QueueFree();
            return;
        }
        else
            exsist = true;
    }
    public void Delete()
    {
        exsist = false;
        this.QueueFree();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionJustPressed("Select1"))
        {
            select1.OnMouseEnter();
        }
        if (Input.IsActionJustPressed("Select2"))
        {
            select2.OnMouseEnter();
        }
        if (Input.IsActionJustPressed("Select3"))
        {
            select3.OnMouseEnter();
        }
        if (Input.IsActionJustPressed("Select4"))
        {
            select4.OnMouseEnter();
        }
        if (Input.IsActionJustReleased("Select1"))
        {
            select1.OnMouseExit();
        }
        if (Input.IsActionJustReleased("Select2"))
        {
            select2.OnMouseExit();
        }
        if (Input.IsActionJustReleased("Select3"))
        {
            select3.OnMouseExit();
        }
        if (Input.IsActionJustReleased("Select4"))
        {
            select4.OnMouseExit();
        }
    }

}
