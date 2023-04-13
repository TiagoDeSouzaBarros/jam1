using Godot;
using System;

public partial class Weapon : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public  Node2D ShootPoint;
	public Sprite2D imagem;
	[Export]
	public int ammo;
	[Export]
	public int maxAmmo;
	private PackedScene bullet;
	public override void _Ready()
	{
		imagem = GetNode<Sprite2D>("image");
		ShootPoint = GetNode<Node2D>("ShootPoint");
		bullet = ResourceLoader.Load<PackedScene>("res://Scenes/regular_bullet.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		imagem.LookAt(GetLocalMousePosition());
	}
	private void OnBecameInvisible() {
		QueueFree();		
	}
	public void Fire(){
		var tiro  = bullet.Instantiate();
		AddChild(tiro);
	}
}
