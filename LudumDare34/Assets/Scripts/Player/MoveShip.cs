﻿using UnityEngine;
using System.Collections;

//Class for controlling the ship
//Also contains the dual button action
public class MoveShip : MonoBehaviour {

	public float currentSpeed = 5;
	public float currentGarbage = 1;

	public float magnetSpeed = 0;
	public bool magnetOnLeft = false;
	public bool magnetOnRight = false;

	float shootTimer = .5f;
	Ship ship;

	public GameObject laserBullet;


	// Use this for initialization
	void Start () {
		Debug.Log("Shiny teeth are go");
		ship = GetComponent<Ship>();

	}

	// Update is called once per frame
	void Update () {
		if (shootTimer > 0f)
			shootTimer -= Time.deltaTime;
		if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
			moveLeft();
		else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
			moveRight();
		else if ( Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
			useAbility();
		else {
			if (magnetOnLeft) {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-magnetSpeed, 0);
			} else if (magnetOnRight) {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (magnetSpeed, 0);
			} else {
				transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}
		}
	}


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

	public void useAbility()
	{
		if (ship.getAmmo() > 0 && shootTimer < 0f)
		{
			Instantiate(laserBullet, transform.position, Quaternion.identity);
			ship.setAmmo(-1);
			shootTimer = .5f;
		}
	}

}
