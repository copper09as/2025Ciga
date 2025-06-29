using Godot;
using System;

public partial class MoveState : PlayerState
{
    public override void Enter()
    {
        player.animated.Play("Walk");
        if (player.isEnterTown)
            SoundManager.Instance.Play("res://Art/Sound/这是两根棍子敲在一起的声音_耳聆网_[声音ID：11208].wav");
        else
        {
            SoundManager.Instance.Play("res://Art/Sound/脚步声与树叶的泥土-自然环境_爱给网_aigei_com.mp3");
        }
    }
    public override void Exit()
    {
        SoundManager.Instance.StopMusic();
    }
    public override void Update(float delta)
    {
        var dir = Input.GetAxis("Left", "Right");
        player.Velocity = new Vector2(dir * player.speed, player.Grivity);
        if (player.isInWall)
        {
            SoundManager.Instance.StopMusic();
        }
        if (Input.IsActionJustPressed("Jump"))
            {
                GD.Print("进入跳跃");
                stateMachine.TransState(State.JumpState);
            }
        if (dir == 0)
        {
            stateMachine.TransState(State.IdleState);
        }
    }
}
