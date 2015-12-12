using UnityEngine;
using System.Collections;

//Controls the basic stats and shit on this fucking garbage ass ship
//Here we go
public class Ship : MonoBehaviour {

	const int DEFAULT_ID = 1;
	public int currentAbility = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getAbility()
	{
		return currentAbility;
	}

	public void setAbility(int id)
	{
		currentAbility = id;
		Debug.Log(id);
	}
}
