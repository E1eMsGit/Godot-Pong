using Godot;

public class Wall : Area2D
{
	[Signal]
    public delegate void ScoreChanged();
	private AudioStreamPlayer _scoreSound;

	public override void _Ready()
	{
		_scoreSound = GetNode<AudioStreamPlayer>("ScoreSound");
	}

	public void OnWallAreaEntered(Area2D area)
	{
		if ((Node2D)area is Ball ball)
		{
			ball.Reset();
			EmitSignal(nameof(ScoreChanged));
			_scoreSound.Play();
		}
	}
}
