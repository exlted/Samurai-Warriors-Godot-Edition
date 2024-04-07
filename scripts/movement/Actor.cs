using System;
using Godot;

namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Actor : Cell
{
	[Signal]
	public delegate void HealthChangedEventHandler(int maxValue, int currentValue);

	[Signal]
	public delegate void TurnTakenEventHandler(Actor actor);

	[Signal]
	public delegate void ActorDiedEventHandler(Actor actor);
	
	protected Grid Map;
	protected int Health = 5;
	protected int MaxHealth = 5;
	protected int Damage = 1;
	[Export] protected bool MyTurn = false;

	protected Actor() : base(Type.Actor)
	{
	}

	~Actor()
	{
		if (MyTurn)
		{
			TurnCompleted();
		}
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
		other.TakeDamage(Damage);
	}

	private void Die()
	{
		Visible = false;
		if (MyTurn)
		{
			TurnCompleted();
		}
		EmitSignal(SignalName.ActorDied, this);
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

	public void SetTurn()
	{
		MyTurn = true;
	}

	protected void TurnCompleted()
	{
		MyTurn = false;
		EmitSignal(SignalName.TurnTaken, this);
	}
}
