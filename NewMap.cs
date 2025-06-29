using Godot;
using System;
using System.Threading.Tasks;

public partial class NewMap : Node2D
{
    [Export]
    private Camera2D camera;
    [Export]
    private AnimatedSprite2D animated;

    public override void _Ready()
    {
        base._Ready();
        //2054.0
        //-2312.0
        var tween = GetTree().CreateTween();
        tween.TweenProperty(camera, "zoom", new Vector2(0.1f, 0.15f), 3);
        var timer = GetTree().CreateTimer(3);
        timer.Timeout += Play;
        
        //tween.TweenProperty(camera, "position", new Vector2(2054.0f, -2312.0f), 3);
    }
    public void Play()
    {
        animated.Play("Grow");
    }

}
