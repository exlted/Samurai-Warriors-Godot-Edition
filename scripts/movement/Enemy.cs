
namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Enemy : Actor
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!MyTurn) return;
		// TODO!: Replace with some form of intelligence
		var targetPosition = Map.RequestMove(this, new Godot.Vector2(1, 0));
		Move(targetPosition);
		TurnCompleted();
	}
}
