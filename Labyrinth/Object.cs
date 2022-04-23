using System;

namespace Labyrinth;
public abstract class Object
{
	public string Symbol;
	public ConsoleColor color = ConsoleColor.White;

	public Coordinates coordinates;
	public Field field;
	private Tile currentTile;

	public bool IsActive = true;

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
				StandOnTile(randomTileCoordinates);
				IsSpawned = true;
			}
		}
	}

	public void StandOnTile(Coordinates TileCoordinates)
    {
		field.StandOnTile(TileCoordinates, this);
		coordinates = TileCoordinates;

		if(currentTile!=null)
        {
			currentTile.ClearObject();
        }

		currentTile = field.GetTile(coordinates);
    }
	public Coordinates GetCoordinates() => coordinates;
}
