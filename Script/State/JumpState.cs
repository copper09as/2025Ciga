using Godot;
using System;

public partial class JumpState : PlayerState
{
    private float curretnHeight;
    private bool canDoubleJump;
    public override void Enter()
    {
        curretnHeight = player.jumpHeight;
        canDoubleJump = true;
    }

    public override void Exit()
    {
        
    }

    public override void Update(float delta)
    {
        var dir = Input.GetAxis("Left", "Right");
        player.Velocity = new Vector2(dir * player.speed, -curretnHeight);
        if (Input.IsActionJustPressed("Jump") &&canDoubleJump)
        {
            curretnHeight = player.jumpHeight;
            canDoubleJump = false;
        }
        if (curretnHeight < 0)
            {
                curretnHeight -= player.Grivity * delta * 3;
            }
            else
                curretnHeight -= player.Grivity * delta;
        if (player.IsOnFloor() && curretnHeight <0)
        {
            if (dir == 0)
            {
                stateMachine.TransState(State.IdleState);
            }
            else
                stateMachine.TransState(State.MoveState);
        }
    }
}
