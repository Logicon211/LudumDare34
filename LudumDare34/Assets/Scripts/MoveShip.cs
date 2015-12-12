using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {

	public  int currentSpeed = 5; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			moveLeft();
		if (Input.GetKeyDown(KeyCode.RightArrow))
			moveRight();
	}


	void moveLeft() 
	{
		Debug.Log("Triggering me left");
	}

	void moveRight()
	{
		Debug.Log("Triggering me right");
	}

}
