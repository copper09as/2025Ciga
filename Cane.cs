using Godot;
using System;

public partial class Cane : Sprite2D
{
    [Export]
    private ShaderMaterial shaderMaterial;
    [Export]
    private Label talk;
    public override void _Process(double delta)
    {
        base._Process(delta);
        shaderMaterial.SetShaderParameter("is_active", PlayerMove.Instance.isInWall);
        if (PlayerMove.Instance.isInWall)
        {
            talk.Show();
        }
        else
        {
            talk.Hide();
        }
    }

}
