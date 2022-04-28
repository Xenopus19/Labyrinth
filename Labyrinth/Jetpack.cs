using System;

namespace Labyrinth;

public class Jetpack : Object
{
	private int ChanceToBeUpgraded = 50;
	private int JumpsAmount = 1;
	public Jetpack(Field field) : base(field)
	{
		SetValues();
		RandomSpawn();
	}

	public void CheckPlayerPosition()
    {
		Player player = (Player)currentTile.FindObjectOfType<Player>();
		if(player!=null)
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
