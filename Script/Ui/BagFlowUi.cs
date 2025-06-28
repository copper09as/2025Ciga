using Godot;
using System;

public partial class BagFlowUi : FlowUi
{
    [Export]
    public Godot.Collections.Array<bool> bag;
    [Export]
    public Godot.Collections.Array<TextureRect> textures;
    [Export]
    private Color initColor;
    [Export]
    private Color transColor;
    protected override void UpdateUi()
    {
        base.UpdateUi();
        for (int i = 0; i < 3; i++)
        {
            if (bag[i])
                textures[i].Modulate = transColor;
            else
                textures[i].Modulate = initColor;
        }
        
    }

}
