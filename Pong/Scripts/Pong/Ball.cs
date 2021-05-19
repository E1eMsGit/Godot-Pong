using Godot;

public class Ball : Area2D
{
	private const int DefaultSpeed = 300;

	private float _speed;
	private byte _hitCounter;
	private Vector2 _direction;
	private Vector2 _initialPos;
	
	public float Speed
	{
		get => _speed;
		set => _speed = value;
	}

	public byte HitCounter
	{
		get => _hitCounter;
		set => _hitCounter = value;
	}
	
	public Vector2 Direction
	{
		get => _direction;
		set => _direction = value;
	}
	
	public override void _Ready()
	{
		Speed = DefaultSpeed;
		HitCounter = 0;
		Direction = Vector2.Left;

		_initialPos = Position;		 
	}

	public override void _Process(float delta)
	{
		Speed += delta * 2;
		Position += Speed * delta * Direction;
	}

	public void Reset()
	{
		HitCounter = 0;
		Direction = Vector2.Left;
		Position = _initialPos;
		Speed = DefaultSpeed;
	}	
}
