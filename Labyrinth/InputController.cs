using System;

namespace Labyrinth;

public class InputController
{
	private Player player;
	public InputController(Player player)
	{
		this.player = player;
	}

	public void GetControls()
	{
		string Control = Console.ReadLine();

		if (Control == "W" || Control == "w")
		{
			player.Move(-1, 0);
		}
		else if (Control == "A" || Control == "a")
		{
			player.Move(0, -1);
		}
		else if (Control == "S" || Control == "s")
		{
			player.Move(1, 0);
		}
		else if (Control == "D" || Control == "d")
		{
			player.Move(0, 1);
		}
	}
}
