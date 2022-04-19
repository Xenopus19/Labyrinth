using System;

namespace Labyrinth;

public class Player : Object
{
	private InputController inputController;
	//private Field field;

	//private Coordinates coordinates;
	public Player(Field field)
	{
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

	/*private void SpawnPlayer()
    {
		Random random = new Random(); 
		bool IsSpawned = false;
		while(!IsSpawned)
        {
			Coordinates randomTileCoordinates = field.GetRandomTile();
			if(field.IsTileMoveable(randomTileCoordinates))
            {
				coordinates = randomTileCoordinates;
				IsSpawned = true;
            }
        }
    }*/
}

public class InputController
{
	private Player player;
	public InputController(Player player)
    {
		this.player = player;
    }

	public void GetControls()
    {
		string Control = Console.ReadLine();

		if(Control == "W" || Control == "w")
        {
			player.Move(-1, 0);
        }
		else if (Control == "A" || Control == "a")
		{
			player.Move(0, -1);
		}
		else if (Control == "S" || Control == "s")
		{
			player.Move(1, 0);
		}
		else if (Control == "D" || Control == "d")
		{
			player.Move(0, 1);
		}
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
