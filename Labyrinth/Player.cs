using System;

namespace Labyrinth;

public class Player : Object
{
	private InputController inputController;

	private int JumpAmount;
	public Player(Field field) : base(field)
	{
		color = ConsoleColor.DarkMagenta;
		Symbol = "K";
		inputController = new InputController(this);
		RandomSpawn();
	}
	

	public void WaitForControls()
    {
		inputController.GetControls();
    }

	public void AddJumps(int Amount)
	{
		JumpAmount += Amount;
	}

	public void Move(int deltaX, int deltaY)
    {
		Coordinates newCoordinates = coordinates + new Coordinates(deltaX, deltaY);

		if (!field.TileExists(newCoordinates)) return;

		if (JumpAmount > 0 && !field.IsTileMoveable(newCoordinates))
        {
			JumpOnTile(newCoordinates);
        }
		else if(field.IsTileMoveable(newCoordinates))
        {
			coordinates = newCoordinates;
        }
    }

	private void JumpOnTile(Coordinates newCoordinates)
    {
		JumpAmount--;
		coordinates = newCoordinates;
    }
}


public struct Coordinates
{
	public int X;
	public int Y;
	public Coordinates(int X, int Y)
    {
		this.X = X;
		this.Y = Y;
    }
	public static Coordinates operator +(Coordinates a, Coordinates b)
    {
		Coordinates Sum = a;
		Sum.X += b.X;
		Sum.Y += b.Y;

		return Sum;
    }
	public static bool operator ==(Coordinates a, Coordinates b)
	{
		return a.X == b.X && a.Y == b.Y;
	}

	public static bool operator !=(Coordinates a, Coordinates b)
	{
		return !(a.X == b.X && a.Y == b.Y);
	}	
}
