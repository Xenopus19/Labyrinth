using System;

namespace Labyrinth;

public class Player : Object
{
	private InputController inputController;

	private int JumpAmount;
	public Player(Field field, string symbol, ConsoleColor Color, PlayerControls controls) : base(field)
	{
		color = Color;
		Symbol = symbol;
		inputController = new InputController(this, controls);
		RandomSpawn();
	}
	

	public void WaitForControls()
    {
		inputController.ControlPlayer();
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
			StandOnTile(newCoordinates);
        }
    }

	private void JumpOnTile(Coordinates newCoordinates)
    {
		JumpAmount--;
		StandOnTile(newCoordinates);
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
