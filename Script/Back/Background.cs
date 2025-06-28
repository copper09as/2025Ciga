using Godot;
using System;

public partial class Background : Sprite2D
{
    [Export]
    private float speed;
    [Export]
    private float autoSpeed;
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (PlayerMove.dir != 0)
        {
            Position = new Vector2((float)(speed * delta*-PlayerMove.dir + Position.X), Position.Y);
        }
        if (autoSpeed != 0)
        {
            Position = new Vector2((float)(autoSpeed * delta + Position.X), Position.Y);
        }
    }

}
