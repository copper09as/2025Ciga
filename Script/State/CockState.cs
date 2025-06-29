using Godot;
using System;

public partial class CockState : PlayerState
{

    public override void Enter()
    {
        player.animated.Play("Poke");
        player.animated.AnimationFinished += TransState;
        player.Velocity = Vector2.Zero;
        player.PlaySound(true);
    }

    public override void Exit()
    {
        player.animated.AnimationFinished -= TransState;
    }

    public override void Update(float delta)
    {
        return;
    }
    private void TransState()
    {
        stateMachine.TransState(State.IdleState);
        SoundManager.Instance.StopMusic();
    }
}
