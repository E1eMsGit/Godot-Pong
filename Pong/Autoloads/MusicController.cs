using Godot;
using System;

public class MusicController : Node
{
    private static AudioStreamPlayer _menuMusic;
    public override void _Ready()
    {
        _menuMusic = GetNode<AudioStreamPlayer>("MenuMusic");
    }

    public static void PlayMenuMusic()
    {
        _menuMusic.Play();
    }

    public static void StopMenuMusic()
    {
        _menuMusic.Stop();
    }
}
