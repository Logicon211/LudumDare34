﻿using UnityEngine;
using System.Collections;

//Class for controlling the ship
//Also contains the dual button action
//This should be named ShipController but hey, ship happens
public class MoveShip : MonoBehaviour {

	public float currentSpeed = 5;
	public float currentGarbage = 1;

	public float magnetSpeed = 0;
	public bool magnetOnLeft = false;
	public bool magnetOnRight = false;
	bool isHeldDown = false;

	float shootTimer = .5f;
	float garbageTimer;
	public const float GARBAGE_DEFAULT = .5f;
	Ship ship;
	public AudioSource audioIn;
	public AudioClip lazerSound;

	public GameObject laserBullet;
	public GameObject garbageParticles;
	public GameObject mainPlayer;


	// Use this for initialization
	void Start () {
		Debug.Log("Shiny teeth are go");
		ship = GetComponent<Ship>();
		garbageTimer = GARBAGE_DEFAULT;
	}

	// Update is called once per frame
	void Update () {
		if (shootTimer > 0f)
			shootTimer -= Time.deltaTime;
		if (garbageTimer > 0f)
			garbageTimer -= Time.deltaTime;
		if (!isHeldDown)
			garbageParticles.SetActive(false);
		if ( Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
		{
			isHeldDown = true;
			useAbility();
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
		{
			garbageTimer = GARBAGE_DEFAULT;
			isHeldDown = false;
			moveLeft();
		}
		else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
		{
			garbageTimer = GARBAGE_DEFAULT;
			isHeldDown = false;
			moveRight();
		}
		else {
			garbageTimer = GARBAGE_DEFAULT;
			isHeldDown = false;
			if (magnetOnLeft) {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-magnetSpeed, 0);
			} else if (magnetOnRight) {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (magnetSpeed, 0);
			} else {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}
		}
	}

	//Move the ship to the left, 
	//Magnets will affect the movement
	public void moveLeft() 
	{	
		if (magnetOnLeft) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-currentSpeed-magnetSpeed, 0);
		} else if (magnetOnRight) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-currentSpeed+magnetSpeed, 0);
		} else {
			transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-currentSpeed , 0);
		}
	}

	//Move the ship to the right
	//Magnets will affect the movement
	public void moveRight()
	{
		if (magnetOnLeft) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentSpeed-magnetSpeed, 0);
		} else if (magnetOnRight) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentSpeed+magnetSpeed, 0);
		} else {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentSpeed, 0);
		}
	}

	//This will use any ability that's on the ship
	//The only ability that this can use is lasers
	public void useAbility()
	{
		if (ship.getGarbage() != 0 && ship.getAmmo() == 0)
		{
			garbageParticles.SetActive(true);
			if (garbageTimer <= 0f)
			{
				ship.loseGarbage(1);
			}
		}
		transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		if (magnetOnLeft) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-magnetSpeed, 0);
		} else if (magnetOnRight) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (magnetSpeed, 0);
		} else {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}
		if (ship.getAmmo() > 0 && shootTimer < 0f)
		{
			audioIn.Stop ();
			audioIn.clip = lazerSound; 
			audioIn.Play ();

			Instantiate(laserBullet, transform.position, Quaternion.identity);
			ship.setAmmo(-1);
			shootTimer = .5f;
		}
	}

}
