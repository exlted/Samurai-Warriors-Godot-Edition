using Godot;
using SamuraiWarriorGodotEdition.scripts.movement;

namespace SamuraiWarriorGodotEdition.scripts;

public partial class MapGenerator : Node2D
{
	[Signal]
	public delegate void ActorCreatedEventHandler(Actor actor);
	
	private int _currentLevel;
	private TileMap _map;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public void Generate(int width, int height)
	{
		//!TODO: Write the logic for generating a new layout for the TileMap
		GD.Print("Called Generate");
	}
	
	public void Load(int level)
	{
		Save();
		_currentLevel = level;
		
		//!TODO: Write the logic for loading the specified level to the TileMap
	}
	
	public void Save()
	{
		//!TODO: Write the logic for saving the level to current_level
	}
	
	private static string Serialize()
	{	
		//!TODO: Write the logic for serializing the TileMap to a string
		// getUsedRec
		return "";
	}
	
	private static string Deserialize()
	{	
		//!TODO: Write the logic for deserializing the TileMap from a string
		return "";
	}
}