﻿using System;

namespace Labyrinth;


public class Game
{
	private Field field;
	private FieldDrawer fieldDrawer;
	private Player player;
	private Exit exit;
	private Jetpack jetpack1;
	private Jetpack jetpack2;

	private List<Object> DrawableObjects;
	
	public Game()
	{
		CreateGameElements();
		InitGraphics();
		
		while (!GameEndConditionReached())
        {
			fieldDrawer.DrawField(DrawableObjects);
			player.WaitForControls();
			jetpack1.CheckPlayerPosition();
			jetpack2.CheckPlayerPosition();
        }

		FinishGame();
	}

	private void CreateGameElements()
    {
		field = new Field(10, 15);
		player = new(field);
		exit = new Exit(field, player);
		jetpack1 = new(field, player);
		jetpack2 = new(field, player);
	}

	private void InitGraphics()
	{
		DrawableObjects = new List<Object>();
		DrawableObjects.Add(player);
		DrawableObjects.Add(exit);
		DrawableObjects.Add(jetpack2);
		DrawableObjects.Add(jetpack1);
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


