using System;
using Godot;
using SamuraiWarriorGodotEdition.scripts.movement;

namespace SamuraiWarriorGodotEdition.scripts.ui;

public partial class Healthbar : Line2D
{
	private Line2D _foreground;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_foreground = GetChild<Line2D>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnHealthChanged(long maxValue, long currentValue)
	{
			var min = Points[0].X;
			var max = Points[1].X;
			var percent = (float)currentValue / maxValue;
			_foreground.SetPointPosition(1, new Vector2((max - min) * percent, _foreground.Points[1].Y));
	}
}
