using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] terrainPieces;
	public GameObject wallPiece;

	public float minX = -30;
	public float maxX = 30;

	public float playerSpeed = 10;

	private float time;
	private Vector2 lastSpawnPosition;
	private GameObject lastWallSpawned;

	public List<GameObject> terrainArray;

	// Use this for initialization
	void Start () {
		time = 0f;
		terrainArray = new List<GameObject> ();

		GameObject leftWall = Instantiate(wallPiece, new Vector3(minX,transform.position.y+10, transform.position.z), transform.rotation) as GameObject;
		GameObject rightWall = Instantiate(wallPiece, new Vector3(maxX,transform.position.y+10, transform.position.z), transform.rotation) as GameObject;

		leftWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		rightWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 1f) {
			//generate something
			GameObject terrainPiece = Instantiate(terrainPieces[0], new Vector3(Random.Range(minX, maxX),transform.position.y+10, transform.position.z), transform.rotation) as GameObject;

			terrainPiece.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
			time = 0f;
		}
	}

	//Fixed Update called at a steady rate
	void FixedUpdate () {

	}
}
