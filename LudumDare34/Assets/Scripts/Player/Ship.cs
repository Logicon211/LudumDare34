using UnityEngine;
using System.Collections;

//Controls the basic stats and shit on this fucking garbage ass ship
//Here we go
public class Ship : MonoBehaviour {

	const int DEFAULT_ID = 0;
	public int currentAbility = 0;
	public int ammo = 0;
    public bool isShielded = false;
	bool isInvincible = false;

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

	public int getAmmo()
	{
		return ammo;
	}

	public void setAmmo(int i)
	{
		ammo += i;
	}

	public void setShield()
	{
		isShielded = true;
	}

	public void setInvincible()
	{
		isInvincible = true;
	}

	public void takeHit()
	{
		if(isInvincible)
		{
			Debug.Log("Invincible");
		}
		else if (isShielded)
		{
			Debug.Log("talk shit get hit");
			isShielded = false;
			//DONT LET THIS GO THROUGH YET
			//IF THIS STAYS ITS MITCH'S FAULT HE TOLD ME
		}
		else{
			Destroy(gameObject);
		}
	}
}
