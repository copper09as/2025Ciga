using Godot;
using System;

public partial class SoundManager : AudioStreamPlayer
{
    public static SoundManager Instance { get; private set; }

    private AudioStreamPlayer soundPlayer;
    public override void _Ready()
    {
        base._Ready();
        soundPlayer = new AudioStreamPlayer();
        this.AddChild(soundPlayer);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            this.QueueFree();
        }
    }
    public void Play(string path)
    {
        var sound = ResourceLoader.Load<AudioStream>(path);
        soundPlayer.Stream = sound;
        soundPlayer.Play();
    }
    public void StopMusic()
    {
        soundPlayer.Stop();
    }

}
