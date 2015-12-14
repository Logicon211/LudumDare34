using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretScript : MonoBehaviour, IEnemy {



	public GameObject garbageShot;
	public float shotSpeed = 5f;

	private bool facingRight = false;
	private float beginningYPosition;

	private float difficulty = 1;
	private float timer;

	public List<GameObject> shotList;
	// Use this for initialization
	void Start () {
		timer = 0f;
		beginningYPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1f) {
			GameObject shot = Instantiate (garbageShot, transform.position, transform.rotation) as GameObject;
			shotList.Add(shot);
			if (facingRight) {
				shot.GetComponent<Rigidbody2D>().velocity = new Vector2 (shotSpeed, transform.gameObject.GetComponent<Rigidbody2D>().velocity.y);
			} else {
				shot.GetComponent<Rigidbody2D>().velocity = new Vector2 (-shotSpeed, transform.gameObject.GetComponent<Rigidbody2D>().velocity.y);
			}
			timer = 0;
		}

		if (transform.position.y < beginningYPosition - 25f) {
			if (transform.parent != null) {
				LevelGenerator levelGen = transform.parent.GetComponent<LevelGenerator> ();
				if (levelGen != null) {
					levelGen.enemyList.Remove (transform.gameObject);
				}
			}
			foreach (GameObject shot in shotList) {
				if (shot != null) {
					Object.Destroy (shot);
				}
			}
			Object.Destroy (this.gameObject);
			//Remove all projectiles too?
		}

	}

	public void FaceRight() {
		facingRight = true;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void SetDifficulty(float dif) {
		difficulty = dif;
	}

	public void updateShotSpeed(float speed) {
		foreach (GameObject shot in shotList) {
			if (shot != null) {
				shot.GetComponent<Rigidbody2D> ().velocity = new Vector2 (shot.GetComponent<Rigidbody2D> ().velocity.x, speed);
			}
		}
	}
}
