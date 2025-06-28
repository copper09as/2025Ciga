using Godot;
using System;
using System.Numerics;

public partial class AppearShader : Node2D
{
    [Export]
    private ShaderMaterial shaderMaterial;
    public bool Show;
    float value = 2.0f;
    public override void _Ready()
    {
        base._Ready();
        value = 2.0f;
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!Show)
            return;
        if (value < 0)
        {
            value = 0;
            shaderMaterial.SetShaderParameter("progress", value);
            value = 2.0f;
            Show = false;
            return;
        }
        value -= (float)delta*2;
        shaderMaterial.SetShaderParameter("progress", value);
        GD.Print(value);
    }

}
