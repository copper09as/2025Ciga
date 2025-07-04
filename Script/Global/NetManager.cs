using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public partial class NetManager : Node
{
    public static NetManager Instance { get; private set; }
    public NetServe netServe;
    public int playerId = -1;

    private NetManager() { }
    public override void _Ready()
    {
        base._Ready();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            this.QueueFree();
        }
    }
    [Rpc(MultiplayerApi.RpcMode.AnyPeer)]
    public void LoadGameManager(int id)
    {
        ResManager.Instance.CreateInstance<GameManager>(StringResource.GameManagerPath, Instance, id.ToString());
        RpcId(id, MethodName.SyncGameManager, id);
        playerId = id;
        GD.Print("转接器已生成");
    }
    [Rpc(MultiplayerApi.RpcMode.Authority)]
    public void SyncGameManager(int id)
    {
        // 客户端仅生成本地副本，不设置权限
        ResManager.Instance.CreateInstance<GameManager>(StringResource.GameManagerPath, this, id.ToString());
        ResManager.Instance.CreateInstance<GameManager>(StringResource.GameManagerPath, NetManager.Instance, "1");
    }
}
