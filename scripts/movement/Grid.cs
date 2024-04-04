using Godot;

namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Grid : TileMap
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private Cell GetCellState(Vector2I location)
	{
		foreach (var child in GetChildren())
		{
			if (child is not Cell cell) continue;
			if (LocalToMap(cell.Position) == location)
			{
				return cell;
			}
		}

		var backgroundCell = GetCellTileData(1, location);
		var isPassable = backgroundCell.GetCustomData("Passable");
		return isPassable.AsBool() ? new Cell(Cell.Type.Empty) : new Cell(Cell.Type.Blocked);
	}

	private static Vector2I NormalizeDirection(Vector2 direction)
	{
		var normalizedDirection = new Vector2I(0, 0);
		if (direction.X != 0)
		{
			if (direction.X > 0)
			{
				normalizedDirection.X = 1;
			}
			else
			{
				normalizedDirection.X = -1;
			}
		}

		if (direction.Y != 0)
		{
			if (direction.Y > 0)
			{
				normalizedDirection.Y = 1;
			}
			else
			{
				normalizedDirection.Y = -1;
			}
		}

		return normalizedDirection;
	}
	
	public Vector2 RequestMove(Actor actor, Vector2 direction)
	{
		var mapPosition = LocalToMap(actor.Position);
		var newPosition = mapPosition + NormalizeDirection(direction);
		
		var cellState = GetCellState(newPosition);
		
		if (cellState is Actor blockingActor)
		{
			actor.Attack(blockingActor);
		}
		
		return MapToLocal(cellState.CellType != Cell.Type.Empty ? mapPosition : newPosition);
	}
}