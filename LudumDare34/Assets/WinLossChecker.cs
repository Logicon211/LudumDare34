using UnityEngine;
using System.Collections;

public class WinLossChecker : MonoBehaviour {

	public GameObject player;
	public GameObject gameEndingBarrel;

	private Ship playerScript;
	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent<Ship>();
	}
	
	// Update is called once per frame
	void Update () {

		if(player == null || playerScript.isDead) {
			StartCoroutine("LoseGame");
		}

		/*if(gameEndingBarrel == null || gameEndingBarrelScript.health <= 0) {
			StartCoroutine("WinGame");
		}*/
	}

	IEnumerator LoseGame() {			
		yield return new  WaitForSeconds(3);  // or however long you want it to wait
		Application.LoadLevel("GameOverScreen");
	}

	IEnumerator WinGame() {			
		yield return new WaitForSeconds(3);  // or however long you want it to wait
		//Application.LoadLevel("VictoryScreen"); //No screen yet for this
	}
}
