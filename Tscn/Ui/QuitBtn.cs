using Godot;
using System;

public partial class QuitBtn : Button
{
    public override void _Ready()
    {
        base._Ready();
        ButtonDown += QuitBtnPress;
    }

    private void QuitBtnPress()
    {
        GetTree().Quit();
    }
}
