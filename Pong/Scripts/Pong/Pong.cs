using Godot;
using System.Collections.Generic;
using System;

public class Pong : Node2D
{
    private Label _lblPause;
    private Label _lblLeftScore;
    private Label _lblRightScore;
    private Sprite _ballSprite;
    private Popup _escMenu;
    private int _leftScore;
    private int _rightScore;
    public override void _Ready()
    {    
        MusicController.StopMenuMusic();
        
        _lblPause = GetNode<Label>("GUI/Pause");
        _lblLeftScore = GetNode<Label>("GUI/LeftScore");
        _lblRightScore = GetNode<Label>("GUI/RightScore");
        _escMenu = GetNode<Popup>("GUI/EscapeMenu");
		_ballSprite = GetNode<Sprite>("Ball/Sprite");
        _ballSprite.Texture = Userdata.GetBallTexture();
    }

    public override void _UnhandledInput(InputEvent @event)
    {
    if (@event is InputEventKey eventKey)
        if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Space)
        {
            if (!_escMenu.Visible)
            {
                GetTree().Paused = GetTree().Paused? false : true;
            }           
        }     
        else if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape)
        {               
             _escMenu.Visible = _escMenu.Visible ? false : true;
             GetTree().Paused = _escMenu.Visible? true : false;
        }    
    }

    private void UpdateLeftScore()
    {
        _leftScore++;
        _lblLeftScore.Text = _leftScore.ToString();      
    }
    private void UpdateRightScore()
    {
        _rightScore++;
        _lblRightScore.Text = _rightScore.ToString();
    }
}
