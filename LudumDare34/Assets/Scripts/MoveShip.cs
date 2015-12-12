using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {

	public  int currentSpeed = 5; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
			moveLeft();
		if (Input.GetKey(KeyCode.RightArrow))
			moveRight();
	}


	void moveLeft() 
	{
		transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
	}

	void moveRight()
	{
		transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);
	}

}
