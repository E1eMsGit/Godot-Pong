using Godot;
using System;

public class Paddle : KinematicBody2D
{
	private const int DefaultSpeed = 250;

	private int _ballDir;
	private string _up;
	private string _down;
	private int _speed;
	private AudioStreamPlayer _hitBallSound;

	public int Speed
	{
		get => _speed;
		set => _speed = value;
	}

	public override void _Ready()
	{
		Speed = DefaultSpeed;
		_hitBallSound = GetNode<AudioStreamPlayer>("HitBallSound");

		string name = Name.ToLower();
		_up = name + "_move_up";
		_down = name + "_move_down";
		_ballDir = name == "left" ? 1 : -1;
	}

    public override void _PhysicsProcess(float delta)
    {
        var motion = new Vector2();
        motion.y = Input.GetActionStrength(_down) - Input.GetActionStrength(_up);
        motion.y /= 2;
        motion = motion.Normalized() * Speed;
        MoveAndSlide(motion);
    }
    

	public void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			ball.Direction = new Vector2(_ballDir, ((float)new Random().NextDouble()) * 2 - 1).Normalized();

			_hitBallSound.Play();

			ball.HitCounter++;
			if (ball.HitCounter == 2)
			{
				ball.Speed += 10;
				ball.HitCounter = 0;
			}			
		}
	}
}
