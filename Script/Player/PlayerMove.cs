using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerMove : CharacterBody2D
{

    [Export]
    private AnimatedSprite2D animated;
    [Export]
    public float speed;
    [Export]
    private StateMachine machine;
    private float grivity;
    [Export]
    public float Grivity
    {
        get
        {
            return grivity * UseGrivity;
        }
        set
        {
            grivity = value;
        }
    }
    private int UseGrivity;
    [Export]
    public float jumpHeight;


    public override void _Process(double delta)
    {
        base._Process(delta);
        machine.Update((float)delta);
        SetGrivity(IsOnFloor());
        MoveAndSlide();
    }
    private void SetGrivity(bool inCeil)
    {
        if (inCeil)
        {
            UseGrivity = 0;
            return;
        }
        UseGrivity = 1;
    }
}
