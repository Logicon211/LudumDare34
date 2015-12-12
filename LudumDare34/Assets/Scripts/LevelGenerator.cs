using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] terrainPieces;
	public GameObject wallPiece;

	public float minX = -30;
	public float maxX = 30;
	public float ySpawnOffset = 10;

	public float playerSpeed = 10;

	private float time;
	private Vector2 lastSpawnPosition;
	private GameObject lastWallSpawned;

	public List<GameObject> terrainList;

	// Use this for initialization
	void Start () {
		time = 0f;
		ySpawnOffset = ySpawnOffset + transform.position.y;
		terrainList = new List<GameObject> ();

		SpawnWalls();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 1f) {
			//generate something
			GameObject terrainPiece = Instantiate(terrainPieces[Random.Range(0, terrainPieces.Length)], new Vector3(Random.Range(minX, maxX),ySpawnOffset, transform.position.z), transform.rotation) as GameObject;
			terrainPiece.transform.parent = transform;

			terrainPiece.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);

			terrainList.Add(terrainPiece);
			time = 0f;
		}
	}

	//Fixed Update called at a steady rate
	void FixedUpdate () {
		if (lastWallSpawned.transform.position.y <= ySpawnOffset - lastWallSpawned.transform.lossyScale.y + 5) {
			SpawnWalls();


		}
	}

	void SpawnWalls ()
	{
		GameObject leftWall = Instantiate (wallPiece, new Vector3 (minX, ySpawnOffset, transform.position.z), transform.rotation) as GameObject;
		GameObject rightWall = Instantiate (wallPiece, new Vector3 (maxX, ySpawnOffset, transform.position.z), transform.rotation) as GameObject;
		leftWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		rightWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);

		leftWall.transform.parent = transform;
		rightWall.transform.parent = transform;

		terrainList.Add(leftWall);
		terrainList.Add(rightWall);

		lastWallSpawned = rightWall;
	}
}
