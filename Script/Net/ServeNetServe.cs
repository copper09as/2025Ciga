using Godot;

public class ServeNetServe : NetServe
{
    private static int connectTimes = 0;
    public ServeNetServe(MultiplayerApi Multiplayer, int port, int max) : base(Multiplayer)
    {
        if (connectTimes == 0)
        {
            Multiplayer.PeerConnected += OnPlayerConnected;
            Multiplayer.PeerDisconnected += OnPlayerDisconnected;
        }
        var peer = new ENetMultiplayerPeer();
        if (peer.CreateServer(port, 2) == Error.Ok)
        {
            Multiplayer.MultiplayerPeer = peer;
            if (Multiplayer.IsServer())
            {
                GD.Print("服务器已成功创建并运行。");
            }
        }
        connectTimes += 1;
    }

    private void OnPlayerConnected(long id)
    {
        if (Multiplayer.IsServer())
        {
            SceneChangeManager.Instance.ChangeScene("res://Tscn/Game/main_game.tscn");
            GD.Print(id);
        }
    }
    private void OnPlayerDisconnected(long id)
    {

    }
}