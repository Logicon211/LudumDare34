using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {



	public GameObject garbageShot;
	public float shotSpeed = 5f;

	bool facingRight = false;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Debug.Log (Time.deltaTime);
		if (timer >= 1f) {
			Debug.Log ("SHOOT GARBAGE");
			GameObject shot = Instantiate (garbageShot, transform.position, transform.rotation) as GameObject;
			if (facingRight) {
				shot.GetComponent<Rigidbody2D>().velocity = new Vector2 (shotSpeed, 0);
			} else {
				shot.GetComponent<Rigidbody2D>().velocity = new Vector2 (-shotSpeed, 0);
			}
			timer = 0;
		}

	}
}
