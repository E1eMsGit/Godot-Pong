using Godot;
using System;

public class EscapeMenu : Popup
{
    public override void _Ready()
    {
        
    }

    public void OnYesButtonPressed()
    {
        GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
        MusicController.PlayMenuMusic();
        GetTree().Paused = false;
    }

    public void OnNoButtonPressed()
    {
        this.Hide();
        GetTree().Paused = false;
    }
}
