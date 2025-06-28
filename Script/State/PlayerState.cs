using Godot;
using System;

public abstract partial class PlayerState : Node
{
    [Export]
    protected StateMachine stateMachine;
    [Export]
    protected PlayerMove player;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update(float delta);

}
