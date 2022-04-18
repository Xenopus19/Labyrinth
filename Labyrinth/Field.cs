﻿using System;

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
		return FieldTiles[tileCoordinates.X, tileCoordinates.Y] == FIELD_EMPTY_TILE;
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

public class FieldDrawer
{
	private Field fieldToDraw;
	private Player player;

	public FieldDrawer(Field field, Player player)
    {
		fieldToDraw = field;
		this.player = player;
    }

	public void CleanField()
    {
		Console.Clear();
    }

	public void DrawField()
    {
		string[,] tiles = fieldToDraw.GetTiles();

		for (int i = 0; i < tiles.GetLength(0); i++)
		{
			for (int j = 0; j < tiles.GetLength(0); j++)
			{
				if(player.GetCoordinates().X == i && player.GetCoordinates().Y == j)
                {
					Console.WriteLine(" " + "K");
                }
				else
                {
					Console.Write(" " + tiles[i, j]);
				}
			}
			Console.WriteLine("");
		}
	}
}
