using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerMove : CharacterBody2D
{
    public static PlayerMove Instance { get; protected set; }
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
            wallDetect.AreaEntered += OnWallEnter;
            wallDetect.AreaExited += OnWallExit;
        }
        else
        {
            this.QueueFree();
        }

    }
    public override void _ExitTree()
    {
        base._ExitTree();
        if (Instance == this)
        {
            Instance = null;
        }

    }
    [Export]
    private Area2D wallDetect;
    [Export]
    public AnimatedSprite2D animated;
    [Export]
    public float speed;
    [Export]
    private CollisionObject2D wallCollision;
    [Export]
    private StateMachine machine;
    public static float dir;
    public bool isInTown = true;
    public bool isEnterTown = false;
    public bool isInWall;
    private float grivity;
    private bool isIntree;
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
    private void OnWallExit(Area2D area)
    {
        if (area.IsInGroup("Wall"))
        {
            isInWall = false;
        }
        else if (area.IsInGroup("Tree"))
        {
            isIntree = false;
        }
    }
    private void OnWallEnter(Area2D area)
    {
        if (area.IsInGroup("Wall"))
        {
            isInWall = true;
        }
        else if (area.IsInGroup("Tree"))
        {
            isIntree = true;
        }
    }
    public void PlaySound(bool isLoop = false,int volume = 0)
    {
        if (isIntree)
        {
            SoundManager.Instance.Play("res://Art/Sound/敲击木头_耳聆网_[声音ID：18757].ogg");
        }
        else if (isEnterTown)
        {
            SoundManager.Instance.Play("res://Art/Sound/这是两根棍子敲在一起的声音_耳聆网_[声音ID：11208].wav");
        }
        if (!isLoop)
        {
            SoundManager.Instance.StopMusic();
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
        if (Input.IsActionJustPressed("Confirm") && isInTown)
        {
            if (isInWall)
            {
                GD.Print("前面没路了");
            }
            else
            {
                GD.Print("前面还有路");
            }
            PlaySound();
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
