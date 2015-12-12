using UnityEngine;
using System.Collections;

public class Garbage : PowerUps {
	
	//public int abilityId = 1;
	// Use this for initializatio
	
	
	override protected void givePowerUp()
	{
		ship.addGarbage(1);
	}
	
	
}
