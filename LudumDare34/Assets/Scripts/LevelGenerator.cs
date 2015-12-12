using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] terrainPieces;
	public GameObject wallPiece;

	public float minX = -30;
	public float maxX = 30;
	public float ySpawnOffset = 10;

	public float playerSpeed = 5;

	private float time;
	private GameObject lastBlockSpawned;
	private GameObject lastWallSpawned;

	public List<GameObject> terrainList;

	// Use this for initialization
	void Start () {
		time = 0f;
		ySpawnOffset = ySpawnOffset + transform.position.y;
		terrainList = new List<GameObject> ();

		SpawnBlocks();
		SpawnWalls();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Fixed Update called at a steady rate
	void FixedUpdate () {
		//Keep left and right walls setup
		Debug.Log( lastWallSpawned.transform.lossyScale.y);
		if (lastWallSpawned.transform.position.y <= ySpawnOffset - lastWallSpawned.transform.GetComponent<BoxCollider2D>().size.y + 0.3) {
			SpawnWalls();
		}
		//Generate another block after the last one has travelled a certain distance
		if (lastBlockSpawned.transform.position.y <= ySpawnOffset - lastWallSpawned.transform.position.y) {
			SpawnBlocks();
		}
	}

	void SpawnWalls ()
	{
		GameObject leftWall = Instantiate (wallPiece, new Vector3 (minX, ySpawnOffset, transform.position.z +1), transform.rotation) as GameObject;
		GameObject rightWall = Instantiate (wallPiece, new Vector3 (maxX, ySpawnOffset, transform.position.z + 1), transform.rotation) as GameObject;
		leftWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		rightWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);

		leftWall.transform.parent = transform;
		rightWall.transform.parent = transform;

		terrainList.Add(leftWall);
		terrainList.Add(rightWall);

		lastWallSpawned = rightWall;
	}

	void SpawnBlocks ()
	{
		GameObject terrainPiece = Instantiate (terrainPieces [Random.Range (0, terrainPieces.Length)], new Vector3 (Random.Range (minX, maxX), ySpawnOffset, transform.position.z + 5), transform.rotation) as GameObject;
		terrainPiece.transform.parent = transform;
		terrainPiece.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		terrainList.Add (terrainPiece);
		lastBlockSpawned = terrainPiece;
	}

	void UpdateSpeed() {
		foreach (GameObject terrainPiece in terrainList) {
			terrainPiece.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		}
	}
}
