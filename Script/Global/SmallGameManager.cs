using Godot;
using System;

public partial class SmallGameManager : Node
{
    public static SmallGameManager Instance { get; private set; }
    public bool isStartSmallGame;
    public Npc currentGameNpc;
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void CreateSmallGame(GameType gameType, Npc npc)
    {
        if (isStartSmallGame)
            return;
        switch (gameType)
        {
            case GameType.Beat:
                var beat_game = ResManager.Instance.CreateInstance<BeatGame>(StringResource.BeatGame, this);
                beat_game.Position = new Vector2(600,100);
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