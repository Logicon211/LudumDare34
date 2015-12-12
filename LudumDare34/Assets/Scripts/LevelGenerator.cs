using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] terrainPieces;

	private float time;

	// Use this for initialization
	void Start () {
		time = 0f;	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 1f) {
			//generate something
			Debug.Log ("GENERATING");
			GameObject terrainPiece = Instantiate(terrainPieces[0], new Vector3(transform.position.x, transform.position.y+10, transform.position.z), transform.rotation) as GameObject;

			terrainPiece.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -10);
			time = 0f;
		}
	}

	//Fixed Update called at a steady rate
	void FixedUpdate () {

	}
}
