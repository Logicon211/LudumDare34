using UnityEngine;
using System.Collections;

public class Invinvible : PowerUps {
	
	//public int abilityId = 1;
	// Use this for initializatio
	
	
	override protected void givePowerUp()
	{
		ship.setAmmo(3);
	}
	
	
}
