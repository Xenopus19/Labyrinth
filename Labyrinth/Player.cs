using System;

namespace Labyrinth;

public class Player
{
	private InputController inputController;
	public Player()
	{
		inputController = new InputController(this);
	}

	public void MakeMovenemt()
    {
		inputController.GetControls();
    }
}

public class InputController
{
	private readonly Player player;
	public InputController(Player player)
    {
		this.player = player;
    }

	public void GetControls()
    {
		string Control = Console.ReadLine();

		
    }
}
