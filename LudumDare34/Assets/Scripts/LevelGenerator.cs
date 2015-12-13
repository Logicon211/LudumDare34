using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] terrainPieces;
	public GameObject[] enemies;
	public GameObject[] powerUps;

	public GameObject wallPiece;
	public GameObject background;

	public float minX = -30;
	public float maxX = 30;

	public float ySpawnOffset = 10;
	public float blockSpawnDistance = 10;
	public float enemySpawnDistance = 10;
	public float powerUpSpawnDistance = 10;

	public float playerSpeed = 5;

	private float time;
	private GameObject lastBlockSpawned;
	private GameObject lastWallSpawned;
	private GameObject lastBackgroundSpawned;
	private GameObject lastEnemySpawned;
	private GameObject lastPowerUpSpawned;

	public List<GameObject> terrainList;
	public List<GameObject> enemyList;
	public List<GameObject> powerupsList;

	// Use this for initialization
	void Start () {
		time = 0f;
		ySpawnOffset = ySpawnOffset + transform.position.y;
		terrainList = new List<GameObject> ();

		//initial wall spawns
		GameObject leftWall = Instantiate (wallPiece, new Vector3 (minX, -5f, transform.position.z +1), transform.rotation) as GameObject;
		GameObject rightWall = Instantiate (wallPiece, new Vector3 (maxX, -5f, transform.position.z + 1), transform.rotation) as GameObject;
		leftWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		rightWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		leftWall.transform.parent = transform;
		rightWall.transform.parent = transform;
		terrainList.Add(leftWall);
		terrainList.Add(rightWall);
		leftWall = Instantiate (wallPiece, new Vector3 (minX, 0, transform.position.z +1), transform.rotation) as GameObject;
		rightWall = Instantiate (wallPiece, new Vector3 (maxX, 0, transform.position.z + 1), transform.rotation) as GameObject;
		leftWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		rightWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		leftWall.transform.parent = transform;
		rightWall.transform.parent = transform;
		terrainList.Add(leftWall);
		terrainList.Add(rightWall);
		leftWall = Instantiate (wallPiece, new Vector3 (minX, 5f, transform.position.z +1), transform.rotation) as GameObject;
		rightWall = Instantiate (wallPiece, new Vector3 (maxX, 5f, transform.position.z + 1), transform.rotation) as GameObject;
		leftWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		rightWall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		leftWall.transform.parent = transform;
		rightWall.transform.parent = transform;
		terrainList.Add(leftWall);
		terrainList.Add(rightWall);

		lastWallSpawned = rightWall;

		//initial background spawns
		GameObject backgroundObject = Instantiate (background, new Vector3 (0, -7.5f, transform.position.z + 10), transform.rotation) as GameObject;
		backgroundObject.transform.parent = transform;
		backgroundObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		terrainList.Add (backgroundObject);
		backgroundObject = Instantiate (background, new Vector3 (0, 0, transform.position.z + 10), transform.rotation) as GameObject;
		backgroundObject.transform.parent = transform;
		backgroundObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		terrainList.Add (backgroundObject);
		backgroundObject = Instantiate (background, new Vector3 (0, 7.5f, transform.position.z + 10), transform.rotation) as GameObject;
		backgroundObject.transform.parent = transform;
		backgroundObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		terrainList.Add (backgroundObject);
		lastBackgroundSpawned = backgroundObject;

		//SpawnBackground();
		SpawnBlocks();
		SpawnEnemies();
		SpawnPowerups();
		//SpawnWalls();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Fixed Update called at a steady rate
	void FixedUpdate () {

		//Generate the background
		if (lastBackgroundSpawned.transform.position.y <= ySpawnOffset - 7.0) {
			SpawnBackground();
		}

		//Generate another block after the last one has travelled a certain distance
		if (lastBlockSpawned.transform.position.y <= ySpawnOffset - blockSpawnDistance) {
			SpawnBlocks();
		}

		//Generate another block after the last one has travelled a certain distance
		if (lastPowerUpSpawned.transform.position.y <= ySpawnOffset - powerUpSpawnDistance) {
			SpawnPowerups();
		}

		//Keep left and right walls setup
		if (lastWallSpawned.transform.position.y <= ySpawnOffset - lastWallSpawned.transform.GetComponent<BoxCollider2D>().size.y + 0.3) {
			SpawnWalls();
		}

		//Keep left and right walls setup
		if (lastEnemySpawned.transform.position.y <= ySpawnOffset - enemySpawnDistance) {
			SpawnEnemies();
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

	void SpawnBackground ()
	{
		GameObject backgroundObject = Instantiate (background, new Vector3 (0, ySpawnOffset, transform.position.z + 10), transform.rotation) as GameObject;
		backgroundObject.transform.parent = transform;
		backgroundObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		terrainList.Add (backgroundObject);
		lastBackgroundSpawned = backgroundObject;
	}

	void SpawnEnemies ()
	{
		//0 is left, 1 is right
		int leftOrRight = Random.Range (0, 2);
		GameObject enemy;

		if (leftOrRight == 0) {
			enemy = Instantiate (enemies [Random.Range (0, enemies.Length)], new Vector3 (minX, ySpawnOffset, transform.position.z), transform.rotation) as GameObject;
			IEnemy ienemy = (IEnemy)enemy.gameObject.GetComponent (typeof(IEnemy));
			ienemy.FaceRight ();
		} else {
			enemy = Instantiate (enemies [Random.Range (0, enemies.Length)], new Vector3 (maxX, ySpawnOffset, transform.position.z), transform.rotation) as GameObject;
		}
		enemy.transform.parent = transform;
		enemy.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		enemyList.Add (enemy);
		lastEnemySpawned = enemy;
	}

	void SpawnPowerups() {
		GameObject powerUpObject = Instantiate (powerUps[Random.Range (0, powerUps.Length)], new Vector3 (Random.Range (minX, maxX), ySpawnOffset, transform.position.z + 5), transform.rotation) as GameObject;
		powerUpObject.transform.parent = transform;
		powerUpObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
		powerupsList.Add (powerUpObject);
		lastPowerUpSpawned = powerUpObject;
		Debug.Log ("POWER UP SPAWNED");
	}

	public void UpdateSpeed(float speed) {
		playerSpeed = speed;
		foreach (GameObject terrainPiece in terrainList) {
			if (terrainPiece != null) {
				terrainPiece.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
			}
		}
		foreach (GameObject enemy in enemyList) {
			if (enemy != null) {
				enemy.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
			}
		}
		foreach (GameObject powerUp in powerupsList) {
			if (powerUp != null) {
				powerUp.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -playerSpeed);
			}
		}
	}
}
