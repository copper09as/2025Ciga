using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerMove : CharacterBody2D
{

    [Export]
    private Area2D wallDetect;
    [Export]
    private AnimatedSprite2D animated;
    [Export]
    public float speed;
    [Export]
    private CollisionObject2D wallCollision;
    [Export]
    private StateMachine machine;
    public static float dir;
    public static bool isInTown = true;
    private bool isInWall;
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
    public override void _Ready()
    {
        base._Ready();
        wallDetect.AreaEntered += OnWallEnter;
        wallDetect.AreaExited += OnWallExit;
    }

    private void OnWallExit(Area2D area)
    {
        if (area.IsInGroup("Wall"))
        {
            isInWall = false;
        }
    }
    private void OnWallEnter(Area2D area)
    {
        if (area.IsInGroup("Wall"))
        {
            isInWall = true;
        }
    }
    private int UseGrivity;
    [Export]
    public float jumpHeight;
    private bool IsWall;
    public override void _Process(double delta)
    {
        base._Process(delta);
        machine.Update((float)delta);
        dir = Input.GetAxis("Left", "Right");
        if (Input.IsActionJustPressed("Rush"))
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(this, "position", new Vector2(Position.X + 420 * dir, Position.Y), 0.1);
        }
        if (Input.IsActionJustPressed("Back"))
        {
            var tween = GetTree().CreateTween();
            tween.TweenProperty(this, "position", new Vector2(Position.X + 420 * (-dir), Position.Y), 0.1);
        }
        SetGrivity(IsOnFloor());
        if (dir > 0)
        {
            animated.FlipH = false;
            wallCollision.Rotation = -90;
        }
        else if (dir < 0)
        {
            animated.FlipH = true;
            wallCollision.Rotation = 90;
        }
        if (Input.IsActionPressed("Confirm") && isInTown)
        {
            if (isInWall)
            {
                GD.Print("前面没路了");
            }
            else
                GD.Print("前面还有路");

        }
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
