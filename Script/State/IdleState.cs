using Godot;
using System;

public partial class IdleState : PlayerState
{
    public override void Enter()
    {
        player.animated.Play("Idle");
    }

    public override void Exit()
    {
    }

    public override void Update(float delta)
    {
        var dir = Input.GetAxis("Left", "Right");
        if (Input.IsActionJustPressed("Jump"))
        {
            GD.Print("进入跳跃");
            stateMachine.TransState(State.JumpState);
        }
        if (dir != 0)
        {
            stateMachine.TransState(State.MoveState);
        }
    }

}
