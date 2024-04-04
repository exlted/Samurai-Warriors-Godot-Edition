using System;
using Godot;

namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Actor : Cell
{
	protected Grid Map;
	protected int Health = 5;
	protected int MaxHealth = 5;
	protected int Damage = 1;
	
	public Actor() : base(Type.Actor)
	{
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Map = GetParent<Grid>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Attack(Actor other)
	{
		GD.Print("Attacking");
		other.Health -= Damage;
		if (other.Health > 0) return;
		other.Health = 0;
		other.Die();
	}

	private void Die()
	{
		GD.Print("Died");
		Visible = false;
		Dispose();
	}
	
	protected void Move(Vector2 newPosition)
	{
		Position = newPosition;
	}
}
