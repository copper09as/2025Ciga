using Godot;
using System;

public partial class BagFlowUi : FlowUi
{
    public static BagFlowUi Instance { get; private set; }
    [Export]
    private Color initCOlor;
    [Export]
    private Color transColor;
    [Export]
    public AnimatedSprite2D animated;
    [Export]
    private Sprite2D quitSprite;
    [Export]
    public Godot.Collections.Array<bool> items = new Godot.Collections.Array<bool>();
    [Export]
    public Godot.Collections.Array<Sprite2D> sprites = new Godot.Collections.Array<Sprite2D>();
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
        }
        else
            this.QueueFree();
        animated.AnimationFinished += animatedFinish;
        foreach (var i in sprites)
        {
            i.Hide();
        }
        GD.Print(items.Count);
        GD.Print(sprites.Count);
    }

    private void animatedFinish()
    {

        animated.Frame = 3; 
        for (int i = 0; i < 3; i++)
        {
            if (items[i])
            {
                sprites[i].Show();
            }
            else
            {
                sprites[i].Hide();
            }
        }
        quitSprite.Show();
    }
    public override void _ExitTree()
    {
        base._ExitTree();
        if (Instance == this)
        {
            Instance = null;
        }
    }
    protected override void UpdateUi()
    {
        base.UpdateUi();
        quitSprite.Hide();
        foreach (var i in sprites)
        {
            i.Hide();
        }
        animated.Frame = 0;
        animated.Play("default");
    }

}
