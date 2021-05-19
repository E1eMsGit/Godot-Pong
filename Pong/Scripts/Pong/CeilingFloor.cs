using Godot;

public class CeilingFloor : Area2D
{
	[Export]
	private int _bounceDirection = 1;
	private AudioStreamPlayer _hitBallSound;

	public override void _Ready()
	{
		_hitBallSound = GetNode<AudioStreamPlayer>("HitBallSound");
	}

	public void OnAreaEntered(Area2D area)
	{
		if ((Node2D)area is Ball ball)
		{
			ball.Direction = (ball.Direction + new Vector2(0, _bounceDirection)).Normalized();
			_hitBallSound.Play();
		}
	}
}