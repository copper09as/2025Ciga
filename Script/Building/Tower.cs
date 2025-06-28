using Godot;
using System;

public partial class Tower : StaticBody2D
{
    [Export]
    public Vector2 InitPosition;
    [Export]
    public PlayerMove playerMove;
    public static Tower Instance { get; private set; }
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
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
}
