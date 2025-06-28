using Godot;
using System;

public partial class SmallGameManager : Node
{
    public static SmallGameManager Instance { get; private set; }
    public bool isStartSmallGame;
    [Export]
    public Vector2 game1;
    [Export]
    public Vector2 game2;
    public Npc currentGameNpc;
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
        }
        else
            QueueFree();
    }
    public void CreateSmallGame(GameType gameType, Npc npc)
    {
        if (isStartSmallGame)
        {
            GD.Print("小游戏正在进行");
            return;
        }
        GD.Print("小游戏开始");
        switch (gameType)
        {
            case GameType.Beat:
                var beat_game = ResManager.Instance.CreateInstance<BeatGame>(StringResource.BeatGame, this);
                beat_game.Position = game1;
                break;
            case GameType.Listen: break;
        }
        isStartSmallGame = true;
        currentGameNpc = npc;
    }
    public void FinishSmallGame()
    {
        isStartSmallGame = false;
        currentGameNpc.isFinishGame = true;
    }
}
public enum GameType
{
    Beat,
    Listen
}