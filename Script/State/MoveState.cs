using Godot;
using System;

public partial class MoveState : PlayerState
{
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update(float delta)
    {
        var dir = Input.GetAxis("Left", "Right");
        player.Velocity = new Vector2(dir * player.speed, player.Grivity);
        if (Input.IsActionJustPressed("Jump"))
        {
            GD.Print("进入跳跃");
            stateMachine.TransState(State.JumpState);
        }
    }
}
