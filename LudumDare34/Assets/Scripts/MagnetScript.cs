using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour, IEnemy {

	private bool facingRight = false;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0f;
	}

	// Update is called once per frame
	void Update () {
		//Pull player towards it?
	}

	public void FaceRight() {
		facingRight = true;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
