using System;

namespace Labyrinth;
public class FieldDrawer
{
	private Field fieldToDraw;
	private Player player;

	public FieldDrawer(Field field, Player player)
	{

		fieldToDraw = field;
		this.player = player;
	}

	public void DrawField(List<Object> drawableObjects)
	{
		Console.Clear();
		string[,] tiles = fieldToDraw.GetTiles();

		for (int i = 0; i < tiles.GetLength(0); i++)
		{
			for (int j = 0; j < tiles.GetLength(1); j++)
			{
				DrawTile(i, j, tiles, drawableObjects);
			}
			Console.WriteLine("");
		}
	}

	private void DrawTile(int X, int Y, string[,] tiles, List<Object> DrawableObjects)
	{
		foreach (Object obj in DrawableObjects)
		{
			if (obj.GetCoordinates().X == X && obj.GetCoordinates().Y == Y)
			{
				DrawElement(obj.Symbol, obj.color);
				return;
			}
		}

		DrawElement(tiles[X, Y]);
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
