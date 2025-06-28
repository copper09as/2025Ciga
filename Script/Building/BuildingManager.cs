using Godot;
using System;

public partial class BuildingManager : Node
{
    [Export]
    private Godot.Collections.Array<Building> buildings;
    public override void _Ready()
    {
        base._Ready();
        //SignalEventCenter.Instance.RegisterEvent(this, MethodName.FinishChose);
    }
    private void FinishChose(int id)
    {
        buildings[0].StartAppear();
    }
}
