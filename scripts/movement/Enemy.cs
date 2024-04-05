using System;
using Godot;
namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Enemy : Actor
{
	private RandomNumberGenerator _rng;

	public Enemy()
	{
		_rng = new RandomNumberGenerator();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!MyTurn) return;
		// TODO!: Replace with some form of intelligence
		var targetPosition = Map.RequestMove(this, GenerateNextDirection());
		Move(targetPosition);
		TurnCompleted();
	}

	private Vector2 GenerateNextDirection()
	{
		var cell = Map.GetPlayer();
		if (cell is not Player player) return new Vector2(_rng.RandiRange(-1, 1), _rng.RandiRange(-1, 1));

		var positionDifference = player.Position - Position;
		var x = positionDifference.X;
		var y = positionDifference.Y;

		return _rng.RandiRange(0, 10) switch
		{
			0 => Vector2.Zero // Don't Move
			,
			< 3 => // Move closer on the X direction
				new Vector2(x < 0 ? -1 : 1, 0),
			< 6 => // Move closer on the Y direction
				new Vector2(0, y < 0 ? -1 : 1),
			< 8 => // Move closer on both directions
				new Vector2(x < 0 ? -1 : 1, y < 0 ? -1 : 1),
			9 => // Move further away on X direction
				new Vector2(x < 0 ? 1 : -1, 0),
			10 => // Move further away on Y direction
				new Vector2(0, y < 0 ? 1 : -1),
			_ => new Vector2(x < 0 ? 1 : -1, y < 0 ? 1 : -1)
		};
	}
}
