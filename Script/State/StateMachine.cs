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
        GD.Print(state.ToString());
    }
}
public enum State
{
    MoveState,
    JumpState

}
