using Godot;
using System;

public partial class UiContain : Control
{
    public static UiContain instance;
    public override void _Ready()
    {
        base._Ready();
        if (instance == null)
            instance = this;
    }
    public override void _ExitTree()
    {
        base._ExitTree();
        instance = null;
    }


    
}
