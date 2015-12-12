using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour, IEnemy {



	public GameObject garbageShot;
	public float shotSpeed = 5f;

	private bool facingRight = false;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1f) {
			GameObject shot = Instantiate (garbageShot, transform.position, transform.rotation) as GameObject;
			if (facingRight) {
				shot.GetComponent<Rigidbody2D>().velocity = new Vector2 (shotSpeed, transform.gameObject.GetComponent<Rigidbody2D>().velocity.y);
			} else {
				shot.GetComponent<Rigidbody2D>().velocity = new Vector2 (-shotSpeed, transform.gameObject.GetComponent<Rigidbody2D>().velocity.y);
			}
			timer = 0;
		}

	}

	public void FaceRight() {
		facingRight = true;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
