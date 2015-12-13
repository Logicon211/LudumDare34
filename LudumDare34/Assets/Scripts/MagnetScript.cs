using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour, IEnemy {

	public float pullSpeed = 4;

	private bool facingRight = false;
	private int difficulty = 1;

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

	public void SetDifficulty(int dif) {
		difficulty = dif;
	}

	public void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			//Pull player towards it
			if (coll.gameObject.transform.position.x > transform.position.x) {
				coll.gameObject.GetComponent<MoveShip> ().magnetOnLeft = true;
				coll.gameObject.GetComponent<MoveShip> ().magnetSpeed = pullSpeed;
				//coll.gameObject.transform.position = new Vector3(coll.gameObject.transform.position.x+pullSpeed, coll.gameObject.transform.position.y, coll.gameObject.transform.position.z);
			} else {
				coll.gameObject.GetComponent<MoveShip> ().magnetOnRight = true;
				coll.gameObject.GetComponent<MoveShip> ().magnetSpeed = pullSpeed;
				//coll.gameObject.transform.position = new Vector3(coll.gameObject.transform.position.x-pullSpeed, coll.gameObject.transform.position.y, coll.gameObject.transform.position.z);
			}
		}
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<MoveShip> ().magnetOnRight = false;
			coll.gameObject.GetComponent<MoveShip> ().magnetOnLeft = false;
			coll.gameObject.GetComponent<MoveShip> ().magnetSpeed = 0;
		}
	}
}
