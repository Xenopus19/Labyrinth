using System;

namespace Labyrinth;
public class Exit : Object
{
	private Player player;
	public Exit(Field field, Player player) : base(field)
	{
		Symbol = "X";
		color = ConsoleColor.Green;
		this.player = player;
		RandomSpawn();
	}

	public bool PlayerReachedExit()
    {
		return player.GetCoordinates() == coordinates;
    }

} 
