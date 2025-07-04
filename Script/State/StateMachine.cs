using Godot;
using System;

public partial class StateMachine : Node
{
    [Export]
    public PlayerState currentState;
    [Export]
    public Godot.Collections.Array<PlayerState> states;
    public void Update(float delta)
    {
        if (Input.IsActionJustPressed("Cock"))
        {
            TransState(State.PokeState);
        }
        currentState.Update(delta);
    }
    public void TransState(State state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        states[(int)state].Enter();
        currentState = states[(int)state];
    }
}
public enum State
{
    MoveState,
    JumpState,
    IdleState,
    PokeState

}
