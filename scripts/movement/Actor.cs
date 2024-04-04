using System;
using Godot;

namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Actor : Cell
{
	protected Grid Map;
	
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
	}

	protected void Move(Vector2 newPosition)
	{
		Position = newPosition;
	}
}
