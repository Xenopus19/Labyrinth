using System;

namespace Labyrinth;
public abstract class Object
{
	public string Symbol;
	public ConsoleColor color = ConsoleColor.White;

	public Coordinates coordinates;
	public Field field;

	public Object(Field field)
    {
		this.field = field;
    }

	public void RandomSpawn()
	{
		Random random = new Random();
		bool IsSpawned = false;
		while (!IsSpawned)
		{
			Coordinates randomTileCoordinates = field.GetRandomTile();
			if (field.IsTileMoveable(randomTileCoordinates))
			{
				coordinates = randomTileCoordinates;
				IsSpawned = true;
			}
		}
	}
	public Coordinates GetCoordinates() => coordinates;
}
