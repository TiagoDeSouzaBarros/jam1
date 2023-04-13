using Godot;
using System;

public partial class Weapon : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public  Node2D ShootPoint;
	public Sprite2D imagem;
	[Export]
	public double intervalShot;
	[Export]
	public double shotTimer;

	[Export]
	public int ammo;
	[Export]
	public int maxAmmo;
	private PackedScene bullet;
	private Vector2 mousePosition;
	public override void _Ready()
	{
		imagem = GetNode<Sprite2D>("Imagem");
		ShootPoint =imagem.GetNode<Node2D>("ShootPoint");
		shotTimer = 0;
		bullet = ResourceLoader.Load<PackedScene>("res://Scenes/RegularBullet.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		mousePosition = GetGlobalMousePosition();

		imagem.LookAt(mousePosition);

		if(Input.IsActionPressed("Fire")  ) Fire(delta);
		shotTimer += delta;

	}
	private void OnBecameInvisible() {
		QueueFree();		
	}
	public void Fire(double delta){
		if(shotTimer >= (delta + intervalShot)){
			var  tiro  = (regular_bullet) bullet.Instantiate();
			var direction = (mousePosition - ShootPoint.Position).Normalized();
			var angle= Mathf.Atan2(direction.Y, direction.X);
			tiro.Position = ShootPoint.Position;
			tiro.Rotation = imagem.Rotation;
			
			//tiro.LookAt(GetGlobalMousePosition());
			
			
			AddChild(tiro);
			shotTimer = 0;
		}
	}
}

