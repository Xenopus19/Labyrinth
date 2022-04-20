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
		CreateGameElements();
		InitGraphics();
		
		while (!GameEndConditionReached())
        {
			fieldDrawer.DrawField(DrawableObjects);
			player.WaitForControls();
        }

		FinishGame();
	}

	private void CreateGameElements()
    {
		field = new Field(10, 15);
		player = new(field);
		exit = new Exit(field, player);
	}

	private void InitGraphics()
	{
		DrawableObjects = new List<Object>();
		DrawableObjects.Add(player);
		DrawableObjects.Add(exit);
		fieldDrawer = new FieldDrawer(field, player);
	}

	private bool GameEndConditionReached()
    {
		return exit.PlayerReachedExit();

	}

	private void FinishGame()
    {
		fieldDrawer.DrawGameFinish();
    }
}


