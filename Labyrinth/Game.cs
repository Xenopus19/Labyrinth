using System;

namespace Labyrinth;


public class Game
{
	private Field field;
	private FieldDrawer fieldDrawer;
	private Player player1;
	private Player player2;
	private Exit exit;
	private Jetpack jetpack1;
	private Jetpack jetpack2;
	
	public Game()
	{
		CreateGameElements();
		InitGraphics();
		
		while (!GameEndConditionReached())
        {
			fieldDrawer.DrawField();
			player1.WaitForControls();
			jetpack1.CheckPlayerPosition();
			jetpack2.CheckPlayerPosition();
        }

		FinishGame();
	}

	private void CreateGameElements()
    {
		field = new Field(10, 15);
		player1 = new(field, "K");
		exit = new Exit(field);
		jetpack1 = new(field);
		jetpack2 = new(field);
	}

	private void InitGraphics()
	{
		fieldDrawer = new FieldDrawer(field);
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


