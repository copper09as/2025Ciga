using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }
    public bool IsHost = false;
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null && !Multiplayer.IsServer())
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
