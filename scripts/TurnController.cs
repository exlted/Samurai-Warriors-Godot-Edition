using System.Collections.Generic;
using System.Linq;
using Godot;
using SamuraiWarriorGodotEdition.scripts.movement;

namespace SamuraiWarriorGodotEdition.scripts;

public partial class TurnController : Node
{
	private Queue<Actor> _turnOrder = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var nodes = GetTree().GetNodesInGroup("actors");
		foreach (var node in nodes)
		{
			if (node is Actor actor)
			{
				_turnOrder.Enqueue(actor);
			}
		}
		NextTurn();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnActorCreated(Actor actor)
	{
		_turnOrder.Enqueue(actor);
	}
	
	public void OnActorDied(Actor actor)
	{
		if (_turnOrder.Peek() == actor)
		{
			_turnOrder.Dequeue();
		}
		else
		{
			_turnOrder = new Queue<Actor>(_turnOrder.Where(x => x != actor));
		}
		GD.Print($"Turns in Queue: {_turnOrder.Count}");
	}
	
	public void OnTurnTaken(Actor actor)
	{
		_turnOrder.Enqueue(actor);
		NextTurn();
	}

	private void NextTurn()
	{
		var nextActor = _turnOrder.Dequeue();
		nextActor.SetTurn();
	}
}