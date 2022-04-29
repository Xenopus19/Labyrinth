using System;

namespace Labyrinth;
public class Exit : Object
{
	public Exit(Field field) : base(field)
	{
		Symbol = "E";
		color = ConsoleColor.DarkBlue;
		RandomSpawn();
	}

	public bool PlayerReachedExit()
    {
		return currentTile.FindObjectOfType<Player>() != null;
    }

} 
