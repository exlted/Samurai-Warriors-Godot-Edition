using System;
using Godot;

namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Actor : Cell
{
	[Signal]
	public delegate void HealthChangedEventHandler(int maxValue, int currentValue);
	
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

	public virtual void Attack(Actor other)
	{
		GD.Print("Attacking");
		other.TakeDamage(Damage);
	}

	private void Die()
	{
		GD.Print("Died");
		Visible = false;
		Dispose();
	}

	private void TakeDamage(int damage)
	{
		Health -= damage;
		EmitSignal(SignalName.HealthChanged, MaxHealth, Health);
		if (Health > 0) return;
		Health = 0;
		Die();
	}
	
	protected void Move(Vector2 newPosition)
	{
		Position = newPosition;
	}
}
