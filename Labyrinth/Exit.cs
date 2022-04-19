using System;

namespace Labyrinth;
public class Exit : Object
{
	private Player player;
	public Exit(Field field, Player player)
	{
		Symbol = "X";
		this.field = field;
		this.player = player;
		RandomSpawn();
	}

	public bool PlayerReachedExit()
    {
		return player.GetCoordinates() == coordinates;
    }

} 
