using UnityEngine;
using System.Collections;

//Class for controlling the ship
//Also contains the dual button action
public class MoveShip : MonoBehaviour {

	public float currentSpeed = 5;
	Ship ship;


	// Use this for initialization
	void Start () {
		Debug.Log("Shiny teeth are go");
		ship = GetComponent<Ship>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
			moveLeft();
		if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
			moveRight();
		if ( Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
			useAbility();
	}


	public void moveLeft() 
	{
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(currentSpeed , 0);
	}

	public void moveRight()
	{
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-currentSpeed , 0);
	}

	public void useAbility()
	{
		string dbout = "the ships current ability is:" + ship.getAbility();
		Debug.Log(dbout);
	}

}
