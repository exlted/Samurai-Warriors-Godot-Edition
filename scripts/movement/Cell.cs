using Godot;
namespace SamuraiWarriorGodotEdition.scripts.movement;

public partial class Cell : Node2D
{
    public enum Type { Actor, Blocked, Empty }

    public Type CellType;

    public Cell(Type type)
    {
        CellType = type;
    }
}