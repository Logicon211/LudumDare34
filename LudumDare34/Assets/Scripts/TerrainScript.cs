using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour, IDestroyable {

	//Using the timer to destroy this object after a certain amount of time so that we don't have a buildup
	private float beginningYPosition;
	Ship ship;

	public GameObject explosionEffect;

	// Use this for initialization
	void Start () {
		//When spawned set velocity down at the same speed as all other terrain objects
		beginningYPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		//destroy object after it travels far enough
		if (transform.position.y < -25f) {
			if (transform.parent != null) {
				LevelGenerator levelGen = transform.parent.GetComponent<LevelGenerator> ();
				if (levelGen != null) {
					levelGen.terrainList.Remove (transform.gameObject);
				}
			}
			Object.Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Check for player collision, blow him up and he loses or whatever
		if (col.gameObject.tag == "Player")
		{
			ship = col.gameObject.GetComponent<Ship>();
			ship.takeHit();
			kill();

		}
	}

	public void kill() {
		Instantiate (explosionEffect, transform.position, transform.rotation);
		//Destroy(gameObject);
		transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		if (transform.gameObject.GetComponent<BoxCollider2D> () != null) {
			transform.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
		if (transform.gameObject.GetComponent<CircleCollider2D> () != null) {
			transform.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		}

		ScoreManager.setScore (ScoreManager.getScore () + 100);
	}
}
