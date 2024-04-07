using Godot;

namespace SamuraiWarriorGodotEdition.scripts.ui;

public partial class PlayerHealthbar : Node
{
	[Export] private Texture2D _full;
	[Export] private Texture2D _half;
	[Export] private Texture2D _empty;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnHealthChanged(long maxValue, long currentValue)
	{
		var children = GetChildren();
		if (maxValue % 2 == 1)
		{
			maxValue += 1;
		}
		if (children.Count < maxValue / 2)
		{
			var spritesToMake = maxValue / 2 - children.Count;
			for (var i = 0; i < spritesToMake; ++i)
			{
				var newSprite = new TextureRect();
				newSprite.Texture = _empty;
				AddChild(newSprite);
				children.Add(newSprite);
			}
		}
		
		foreach (var node in children)
		{
			var child = (TextureRect)node;
			switch (currentValue)
			{
				case >= 2:
					child.Texture = _full;
					currentValue -= 2;
					continue;
				case 1:
					child.Texture = _half;
					currentValue -= 1;
					continue;
				default:
					child.Texture = _empty;
					break;
			}
		}
	}
}