using Godot;
using System;

public partial class regular_bullet : Area2D
{
	[Export]
	public int damage;
	[Export]
	public float speed;
	private Vector2 direction;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		direction = GetLocalMousePosition().Normalized();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += direction * speed;
	}
}
