using Godot;
using System;
using System.IO;

public partial class SoundManager : AudioStreamPlayer
{
    public static SoundManager Instance { get; private set; }

    public AudioStreamPlayer soundPlayer;
    public string currentPath;
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
        soundPlayer.Finished +=Loop;
    }

    private void Loop()
    {
        if (currentPath != "")
        {
            var path = currentPath;
            var sound = ResourceLoader.Load<AudioStream>(path);
            currentPath = path;
            soundPlayer.Stream = sound;
            soundPlayer.Playing = true;
            soundPlayer.Play(); 
        }
    }


    public void Play(string path, int volume = 0)
    {
        var sound = ResourceLoader.Load<AudioStream>(path);
        currentPath = path;
        soundPlayer.Stream = sound;
        soundPlayer.VolumeDb = volume;
        soundPlayer.Playing = true;
        soundPlayer.Play();

    }
    public void StopMusic()
    {
        soundPlayer.Stop();
        currentPath = "";
    }
    

}
