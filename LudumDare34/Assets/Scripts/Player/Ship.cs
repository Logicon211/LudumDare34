using UnityEngine;
using System.Collections;

//Controls the basic stats and shit on this fucking garbage ass ship
//Here we go
public class Ship : MonoBehaviour {

	const int DEFAULT_ID = 0;
	public int currentAbility = 0;
	public int ammo;
	int garbage = 0;
	int previousGarbage = 0;
    public bool isShielded = false;
	public bool isInvincible = false;
	float invincibleTime = 0f;
	public GameObject spriteIn; //Used for changing the amount of ammo we have.
	private SpriteRenderer ammoRenderer;
	public Sprite threeBullets;
	public Sprite twoBullets;
	public Sprite oneBullet;
	public Sprite cleanShip;
	public Sprite dirtyShip;
	public Conversations convIn;
	const float SIZE = .1f;
	//Not needed anymore but I'm keeping it
	const float DEFAULT_DIRTY_SHIP_SIZE_BECAUSE_MITCH_FUCKED_UP_AND_NOT_ME_X_VALUE = 1f;
	const float DEFAULT_DIRTY_SHIP_SIZE_BECAUSE_MITCH_FUCKED_UP_AND_NOT_ME_Y_VALUE = 1f;
	public bool isDead = false;
	public GameObject HYYYYPADRIIIIIIIIIIIIIIIIVE;

	SpriteRenderer shieldSprite;
	SpriteRenderer thisSprite;
	LevelGenerator levelGen;

	public AudioSource boostoIn;
	public AudioClip boostSound;

	// Use this for initialization
	void Start () {
		ammo = 0;
		levelGen = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
		shieldSprite = transform.FindChild("ShieldContainer").GetComponent<SpriteRenderer>();
		ammoRenderer = spriteIn.GetComponent<SpriteRenderer>();
		thisSprite = gameObject.GetComponent<SpriteRenderer>();
		boostoIn.volume = 0.70f;
	}
	
	// Update is called once per frame
	void Update () {
		changeSize();
		if (isInvincible)
		{
			HYYYYPADRIIIIIIIIIIIIIIIIVE.SetActive(true);
			levelGen.UpdateSpeed(10f);
			invincibleTime -= Time.deltaTime;
			if (invincibleTime <= 0f)
			{
				HYYYYPADRIIIIIIIIIIIIIIIIVE.SetActive(false);
				isInvincible = false;
				levelGen.UpdateSpeed (5f);
			}
		}
	}


	//Changes the size of the ship
	public void changeSize()
	{
		if (garbage == 0)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = cleanShip;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = dirtyShip;
		}
		if (garbage != previousGarbage)
		{
			if (garbage == 0)
			{

			transform.localScale = new Vector3(1 + (garbage * SIZE), 1 + (garbage * SIZE), 1);
			}
			else
			{
				transform.localScale = new Vector3(DEFAULT_DIRTY_SHIP_SIZE_BECAUSE_MITCH_FUCKED_UP_AND_NOT_ME_X_VALUE + (garbage * SIZE), DEFAULT_DIRTY_SHIP_SIZE_BECAUSE_MITCH_FUCKED_UP_AND_NOT_ME_Y_VALUE + (garbage * SIZE), 1);

			}
			previousGarbage = garbage;
		}
	}

	//Add to the garbage int 
	public void addGarbage(int i)
	{
		garbage += i;
	}

	//Subtract from the amount of garbage on the shipp
	public void loseGarbage(int i)
	{
		garbage -= i;
		if (garbage < 0)
			garbage = 0;
	}

	public int getGarbage()
	{
		return garbage;
	}

	//Returns the amount of ammo currently on ship
	public int getAmmo()
	{
		return ammo;
	}


	//This calls the poweruppickup function in conversation. 3 is shields, 2 is lazers, 1 is speed boost.
	public void shipConvo(int i){
		convIn.PowerupPickup (i);
	}

	//Give the ship i amount of ammo (Max 3)
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

	//Gain a shield
	public void setShield()
	{
		if (!isShielded) {
			shipConvo (3);
			isShielded = true;
		shieldSprite.enabled = true;
		}
	}

	//Lose the shield 
	public void loseShield()
	{
		isShielded = false;
		shieldSprite.enabled = false;
	}

	//Sets the boost and invincibility
	public void setInvincible()
	{
		boostoIn.Stop ();
		boostoIn.clip = boostSound; 
		boostoIn.Play ();
		shipConvo (1);
		isInvincible = true;
		invincibleTime = 6f;

	}

	//Take a hit for the team
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
