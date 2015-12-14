using UnityEngine;
using System.Collections;

public class Garbage : PowerUps {
	
	//public int abilityId = 1;
	// Use this for initializatio

	public AudioClip garbageSplat;

	void Update() {
		//playSound ();
	}

	override protected void givePowerUp()
	{
		playSound ();
		ship.addGarbage(1);
	}

	private void playSound() {
		AudioSource audio = gameObject.GetComponent<AudioSource> ();
		Debug.Log (audio.clip);
		audio.Play ();
	}
	
	
}
