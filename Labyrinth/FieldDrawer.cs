using System;

namespace Labyrinth;
public class FieldDrawer
{
	private Field fieldToDraw;

	public FieldDrawer(Field field)
	{

		fieldToDraw = field;
	}

	public void DrawField()
	{
		Console.Clear();
		Tile[,] tiles = fieldToDraw.GetTiles();

		for (int i = 0; i < tiles.GetLength(0); i++)
		{
			for (int j = 0; j < tiles.GetLength(1); j++)
			{
				DrawTile(tiles[i, j]);
			}
			Console.WriteLine("");
		}
	}

	private void DrawTile(Tile tile)
	{
		Object tileObject = tile.GetObject();
		if(tileObject != null && tileObject.IsActive)
        {
			DrawElement(tileObject.Symbol, tileObject.color);
        }
		else
        {
			DrawElement(tile.FieldPart);
        }
	}

	private void DrawElement(string Symbol, ConsoleColor color)
    {
		Console.ForegroundColor = color;
		Console.Write(" " + Symbol);
		Console.ForegroundColor= ConsoleColor.White;
    }
	private void DrawElement(string Symbol)
	{
		Console.Write(" " + Symbol);
	}

	public void DrawGameFinish()
    {
		Console.Clear();
		Console.WriteLine("They all lived happily ever after.");
    }
}
