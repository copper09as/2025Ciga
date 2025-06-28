using Godot;
using System;

public partial class JumpState : PlayerState
{
    private float curretnHeight;
    public override void Enter()
    {
        curretnHeight = player.jumpHeight;
    }

    public override void Exit()
    {
        
    }

    public override void Update(float delta)
    {
        var dir = Input.GetAxis("Left", "Right");
        player.Velocity = new Vector2(dir * player.speed, -curretnHeight);
        if (curretnHeight < 0)
        {
            curretnHeight -= player.Grivity * delta*3;
        }
        else
            curretnHeight -= player.Grivity * delta;
        if (player.IsOnFloor() && curretnHeight <0)
        {
            stateMachine.TransState(State.MoveState);
        }
    }
}
