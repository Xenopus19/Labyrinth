using System;

namespace Labyrinth;

public class Field
{
	public static string FIELD_EMPTY_TILE = " ";
	public static string FIELD_BRICK_TILE = "#";

	private Tile[,] FieldTiles;


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
		return FieldTiles[tileCoordinates.X, tileCoordinates.Y].FieldPart == FIELD_EMPTY_TILE;
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

	public Tile StandOnTile(Coordinates tileCoordinates, Object newObject)
    {
		Tile tile = FieldTiles[tileCoordinates.X, tileCoordinates.Y];
		tile.SetObject(newObject);
		return tile;
    }

	public Tile[,] GetTiles()
    {
		return FieldTiles;
    }

	public Tile GetTile(Coordinates coordinates)
	{
		return FieldTiles[coordinates.X, coordinates.Y];
	}


	private void CreateField(int FieldSize, int BrickDensity)
    {
		FieldTiles = new Tile[FieldSize, FieldSize];
		for (int i = 0; i < FieldSize; i++)
		{
			for (int j = 0; j < FieldSize; j++)
			{
				FieldTiles[i, j] = new(BrickDensity);
			}
		}
	}
}

public class Tile
{
	private List<Object> OnTileObjects;
	public string FieldPart;

	public Tile(int ChanceToBeBrick)
    {
		OnTileObjects = new List<Object>();
		SetFieldPart(ChanceToBeBrick);
    }

	public void SetObject(Object newObject)
    {
		OnTileObjects.Add(newObject);
    }

	public void ClearObject(Object objectToClean)
    {
		OnTileObjects.Remove(objectToClean);
    }

	public Object GetObject()
    {
		if(OnTileObjects.Count == 0) return null;
		return OnTileObjects.Last();
    }

	private void SetFieldPart(int ChanceToBeBrick)
	{
		Random random = new Random();
		int Chance = random.Next(100);

		FieldPart = Chance <= ChanceToBeBrick ? Field.FIELD_BRICK_TILE : Field.FIELD_EMPTY_TILE;
	}
}

