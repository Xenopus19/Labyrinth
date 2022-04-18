using System;

namespace Labyrinth;


public class Game
{
	private Field field;
	private FieldDrawer fieldDrawer;
	private Player player;
	public Game()
	{
		player = new Player();
		field = new Field(10, 15);
		fieldDrawer = new FieldDrawer(field);
		while (true)
        {
			fieldDrawer.DrawField();
			player.MakeMovenemt();
			//fieldDrawer.CleanField();
        }
	}
}


