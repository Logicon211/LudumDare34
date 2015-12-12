using UnityEngine;
using System.Collections;

public class Lasers : PowerUps {
	
	//public int abilityId = 1;
	// Use this for initializatio


	override protected void givePowerUp()
	{
		ship.setAmmo(3);
	}
	

}
