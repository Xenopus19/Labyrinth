using System;

namespace Labyrinth;

public class Player : Object
{
	private InputController inputController;

	public Player(Field field)
	{
		color = ConsoleColor.DarkMagenta;
		Symbol = "K";
		this.field = field;
		inputController = new InputController(this);
		RandomSpawn();
	}
	

	public void WaitForControls()
    {
		inputController.GetControls();
    }

	public void Move(int deltaX, int deltaY)
    {
		Coordinates newCoordinates = coordinates + new Coordinates(deltaX, deltaY);

		if(field.IsTileMoveable(newCoordinates))
			coordinates = newCoordinates; 
    }
}


public struct Coordinates
{
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

	public int X;
	public int Y;
}
