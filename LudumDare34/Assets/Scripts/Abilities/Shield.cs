using UnityEngine;
using System.Collections;

public class Shield : PowerUps {
	
	//public int abilityId = 1;
	// Use this for initializatio
	
	
	override protected void givePowerUp()
	{
		ship.setShield();
	}
	
	
}
