using Godot;
using System;

public class MainMenu : Control
{
    public override void _Ready()
    {

    }

    public void OnPlayPressed()
    {
        GetTree().ChangeScene("res://Scenes/Pong.tscn");
    }

    public void OnRecordsPressed()
    {
        GetTree().ChangeScene("res://Scenes/Records.tscn");
    }

    public void OnSettingsPressed()
    {
        GetTree().ChangeScene("res://Scenes/Settings.tscn");
    }

    public void OnExitPressed()
    {
        GetTree().Quit();
    }  
}
