using System;

namespace Labyrinth;


public class Game
{
	private Field field;
	private FieldDrawer fieldDrawer;
	private Player player;
	public Game()
	{
		
		field = new Field(10, 15);
		player = new(field);
		fieldDrawer = new FieldDrawer(field, player);
		while (true)
        {
			fieldDrawer.DrawField();
			player.WaitForControls();
			//fieldDrawer.CleanField();
        }
	}
}


