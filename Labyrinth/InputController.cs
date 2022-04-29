using System;

namespace Labyrinth;

public struct PlayerControls
{
	public PlayerControls(ConsoleKey up, ConsoleKey down, ConsoleKey left, ConsoleKey right)
    {
		UpKey = up;
		DownKey = down;
		LeftKey = left;
		RightKey = right;
    }

	public ConsoleKey UpKey;
	public ConsoleKey DownKey;
	public ConsoleKey LeftKey;
	public ConsoleKey RightKey;
}

public class InputController
{
	private static ConsoleKey Control;

	private Player player;
	private PlayerControls controls;
	public InputController(Player player, PlayerControls Controls)
	{
		this.player = player;
		controls = Controls;
	}

	public static void GetControl()
    {
		Control = Console.ReadKey().Key;
	}

	public void ControlPlayer()
	{
		if (Control == controls.UpKey)
		{
			player.Move(-1, 0);
		}
		else if (Control == controls.LeftKey)
		{
			player.Move(0, -1);
		}
		else if (Control == controls.DownKey)
		{
			player.Move(1, 0);
		}
		else if (Control == controls.RightKey)
		{
			player.Move(0, 1);
		}
	}
}
