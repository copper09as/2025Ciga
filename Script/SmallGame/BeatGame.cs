using Godot;
using System;

public partial class BeatGame : Node2D
{
    [Export]
    private Timer timer;
    [Export]
    private Godot.Collections.Array<Sprite2D> stars;
    [Export]
    private Godot.Collections.Array<int> starIndex;
    private int currentStart = -1;
    [Export]
    private Color initColor;
    [Export]
    private Color transColor;
    [Export]
    private Color winColor;
    public override void _Ready()
    {
        base._Ready();
        timer.Timeout += OnTimerOut;
        OnTimerOut();
        foreach (var i in stars)
        {
            i.Modulate = initColor;
        }
        timer.Start();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (Input.IsActionJustPressed("Select1"))
        {
            if (currentStart == 0)
            {
                starIndex.Remove(0);
                var tween = GetTree().CreateTween();
                GD.Print("砸中了");
                tween.TweenProperty(stars[currentStart], "modulate", winColor, 0.3);
                currentStart = -1;
                timer.Start();
            }

        }
        else if (Input.IsActionJustPressed("Select2"))
        {
            if (currentStart == 1)
            {
                starIndex.Remove(1);
                var tween = GetTree().CreateTween();
                GD.Print("砸中了");
                tween.TweenProperty(stars[currentStart], "modulate", winColor, 0.3);
                currentStart = -1;
                timer.Start();
            }
        }
        else if (Input.IsActionJustPressed("Select3"))
        {
            if (currentStart == 2)
            {
                starIndex.Remove(2);
                var tween = GetTree().CreateTween();
                GD.Print("砸中了");
                tween.TweenProperty(stars[currentStart], "modulate", winColor, 0.3);
                currentStart = -1;
                timer.Start();
            }
        }
        else if (Input.IsActionJustPressed("Select4"))
        {
            if (currentStart == 3)
            {
                starIndex.Remove(3);
                var tween = GetTree().CreateTween();
                GD.Print("砸中了");
                tween.TweenProperty(stars[currentStart], "modulate", winColor, 0.3);
                currentStart = -1;
                timer.Start();
            }
        }
    }
    private void OnTimerOut()
    {
        int index = GD.RandRange(0, 3);
        TransStar();
    }
    private void TransStar()
    {
        if (starIndex.Count == 0)
        {
            timer.Stop();
            SmallGameManager.Instance.FinishSmallGame();
            QueueFree();
            return;
        }
        var tween = GetTree().CreateTween();
        var index = starIndex.PickRandom();
        if (currentStart != -1)
        {
            tween.TweenProperty(stars[currentStart], "modulate", initColor, 0.2);
        }
        currentStart = index;
        tween.TweenProperty(stars[currentStart], "modulate", transColor, 0.3);
    }

}
