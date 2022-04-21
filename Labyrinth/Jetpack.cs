using System;

namespace Labyrinth;

public class Jetpack : Object
{
	private Player player;
	private int ChanceToBeUpgraded = 50;
	private int JumpsAmount = 1;
	public Jetpack(Field field, Player player) : base(field)
	{
		this.player = player;
		SetValues();
		RandomSpawn();
	}

	public void CheckPlayerPosition()
    {
		if (player.GetCoordinates() == coordinates && IsActive)
        {
			player.AddJumps(JumpsAmount);
			IsActive = false;
		}
			
    }

	private void SetValues()
    {
		Random random = new Random();

		if(random.Next(100)<=ChanceToBeUpgraded)
        {
			UpgradeJetpack();
        }
		else
        {
			Symbol = "j";
			color = ConsoleColor.DarkRed;
        }
    }

	private void UpgradeJetpack()
    {
		Symbol = "J";
		color = ConsoleColor.Red;
		JumpsAmount++;
    }
}
