using System;

namespace Labyrinth;
public class Exit : Object
{
	public Exit(Field field) : base(field)
	{
		Symbol = "X";
		color = ConsoleColor.Green;
		RandomSpawn();
	}

	public bool PlayerReachedExit()
    {
		return currentTile.FindObjectOfType<Player>() != null;
    }

} 
