using System;

namespace Labyrinth;

public class Field
{
	private const string FIELD_EMPTY_TILE = " ";
	private const string FIELD_BRICK_TILE = "#";

	private string[,] FieldTiles;


	public Field(int FieldSize, int BrickDensity)
	{ 
		CreateField(FieldSize, BrickDensity);
	}
	public Coordinates GetRandomTile()
    {
		Random random = new Random();

		return new Coordinates(random.Next(FieldTiles.GetLength(0)), random.Next(FieldTiles.GetLength(0)));
    }
	public bool IsTileMoveable(Coordinates tileCoordinates)
    {
		if(!TileExists(tileCoordinates))
        {
			return false;
        }
		return FieldTiles[tileCoordinates.X, tileCoordinates.Y] == FIELD_EMPTY_TILE;
    }

	public bool TileExists(Coordinates tileCoordinates)
    {
		if (tileCoordinates.X > FieldTiles.GetLength(0)-1 || tileCoordinates.Y > FieldTiles.GetLength(0)-1)
        {
			return false;
		}
		else if(tileCoordinates.X < 0 || tileCoordinates.Y < 0)
        {
			return false;
        }

		return true;
    }

	public string[,] GetTiles()
    {
		return FieldTiles;
    }

	private void CreateField(int FieldSize, int BrickDensity)
    {
		FieldTiles = new string[FieldSize, FieldSize];
		for (int i = 0; i < FieldSize; i++)
		{
			for (int j = 0; j < FieldSize; j++)
			{
				FieldTiles[i, j] = GenerateTile(BrickDensity);
			}
		}
	}

	private string GenerateTile(int ChanceToBeBrick)
    {
		Random random = new Random();
		int Chance = random.Next(100);

		string tile = Chance<=ChanceToBeBrick ? FIELD_BRICK_TILE : FIELD_EMPTY_TILE;
		return tile;
	}
}


