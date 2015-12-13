using UnityEngine;
using System.Collections;

//Controls the basic stats and shit on this fucking garbage ass ship
//Here we go
public class Ship : MonoBehaviour {

	const int DEFAULT_ID = 0;
	public int currentAbility = 0;
	public int ammo = 0;
	int garbage = 0;
    public bool isShielded = false;
	public bool isInvincible = false;
	float invincibleTime = 0f;

	LevelGenerator levelGen;

	// Use this for initialization
	void Start () {
		levelGen = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isInvincible)
		{
			levelGen.UpdateSpeed(10f);
			invincibleTime -= Time.deltaTime;
			if (invincibleTime <= 0f)
			{
				isInvincible = false;
				levelGen.UpdateSpeed (5f);
			}
		}
	}

	public void addGarbage(int i)
	{
		garbage += i;
	}

	public void loseGarbage(int i)
	{
		garbage -= i;
		if (garbage < 0)
			garbage = 0;
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

	public void loseShield()
	{
		isShielded = false;
	}

	public void setInvincible()
	{
		isInvincible = true;
		invincibleTime = 3f;
	}

	public void takeHit()
	{
		if (isShielded)
		{
			loseShield();
		}
		else if (isInvincible)
		{

		}
		else{
			Destroy(gameObject);
		}
	}
}
