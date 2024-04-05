using Godot;

namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Player : Actor
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!MyTurn) return;
		
		var inputDirection = GetInputDirection();
		if (inputDirection.IsZeroApprox())
		{
			return;
		}

		var targetPosition = Map.RequestMove(this, inputDirection);
		Move(targetPosition);
		
		TurnCompleted();
	}
	
	private static Vector2 GetInputDirection()
	{
		Input.IsActionJustPressed("ui_right");

		return new Vector2(
			Input.IsActionJustPressed("ui_right") ? 1 : Input.IsActionJustPressed("ui_left") ? -1 : 0,
			Input.IsActionJustPressed("ui_down") ? 1 : Input.IsActionJustPressed("ui_up") ? -1 : 0
			);
	}
}
