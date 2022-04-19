using System;

namespace Labyrinth;


public class Game
{
	private Field field;
	private FieldDrawer fieldDrawer;
	private Player player;
	private Exit exit;

	private List<Object> DrawableObjects;
	
	public Game()
	{
		
		field = new Field(10, 15);
		player = new(field);
		exit = new Exit(field, player);
		InitDrawableObjects();
		fieldDrawer = new FieldDrawer(field, player);
		while (!exit.PlayerReachedExit())
        {
			fieldDrawer.DrawField(DrawableObjects);
			player.WaitForControls();
        }

		FinishGame();
	}

	private void InitDrawableObjects()
	{
		DrawableObjects = new List<Object>();
		DrawableObjects.Add(player);
		DrawableObjects.Add(exit);
	}

	private void FinishGame()
    {
		fieldDrawer.DrawGameFinish();
    }
}


