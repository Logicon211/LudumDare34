﻿using UnityEngine;
using System.Collections;

//Controls the basic stats and shit on this fucking garbage ass ship
//Here we go
public class Ship : MonoBehaviour {

	const int DEFAULT_ID = 0;
	public int currentAbility = 0;
	public int ammo;
	int garbage = 0;
    public bool isShielded = false;
	public bool isInvincible = false;
	float invincibleTime = 0f;
	public GameObject spriteIn; //Used for changing the amount of ammo we have.
	private SpriteRenderer ammoRenderer;
	public Sprite threeBullets;
	public Sprite twoBullets;
	public Sprite oneBullet;
	public Conversations convIn;

	public bool isDead = false;
	SpriteRenderer shieldSprite;
	LevelGenerator levelGen;

	// Use this for initialization
	void Start () {
		ammo = 0;
		levelGen = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
		shieldSprite = transform.FindChild("ShieldContainer").GetComponent<SpriteRenderer>();
		ammoRenderer = spriteIn.GetComponent<SpriteRenderer>();
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


	//This calls the poweruppickup function in conversation. 3 is shields, 2 is lazers, 1 is speed boost.
	public void shipConvo(int i){
		convIn.PowerupPickup (i);
	}

	public void setAmmo(int i)
	{
		ammo += i;

		if (ammo >= 3) {
			ammoRenderer.sprite = threeBullets;
			ammo = 3;
			shipConvo (2);
		} 
		else if (ammo == 2) {
			ammoRenderer.sprite = twoBullets;
		}
		else if (ammo ==1){
			ammoRenderer.sprite = oneBullet;
		}
		else{
			ammoRenderer.sprite = null;
		}
	}

	public void setShield()
	{
		if (!isShielded) {
			shipConvo (3);
			isShielded = true;
		shieldSprite.enabled = true;
		}
	}

	public void loseShield()
	{
		isShielded = false;
		shieldSprite.enabled = false;
	}

	public void setInvincible()
	{
		shipConvo (1);
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
			isDead = true;
			transform.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			//disable collider and stuff too?
		}
	}
}
