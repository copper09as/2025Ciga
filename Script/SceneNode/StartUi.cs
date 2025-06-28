using Godot;
using System;
public partial class StartUi : Control
{
    [Export] private Button ServeBtn;
    [Export] private Button ClientBtn;
    [Export] public LineEdit Iptxt;
    [Export] public LineEdit PortTxt;
    public override void _Ready()
    {
        base._Ready();
        ServeBtn.Pressed += OnServeBtn;
        ClientBtn.Pressed += OnClientBtn;
    }
    public void OnServeBtn()
    {
        ResManager.Instance.CreateInstance<GameManager>(StringResource.GameManagerPath, NetManager.Instance, "1");
        NetManager.Instance.netServe = new ServeNetServe(NetManager.Instance.Multiplayer, int.Parse(PortTxt.Text), 10);
    }
    public void OnClientBtn()
    {
        NetManager.Instance.netServe = new ClientNetServe(NetManager.Instance.Multiplayer, Iptxt.Text, int.Parse(PortTxt.Text));
    }

}
