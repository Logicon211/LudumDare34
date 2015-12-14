﻿using UnityEngine;
using System.Collections;

public class Conversations : MonoBehaviour {

	//Face will hold the image that we will display. the public sprites will be the faces we will use.
	public Sprite Face;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Animator door;
	private SpriteRenderer spriteRenderer;
	public AudioSource AUDI;
	public AudioClip goFastCraig;
	//public AudioClip goodLuckOutThere;	outdated
	public AudioClip hesAMadMan;
	public AudioClip INeverLose;
	public AudioClip shieldFullPower;
	public AudioClip takeOutTheTrash;
	public AudioClip timeToTakeOutTrash;
	public AudioClip youllNeverMakeit;
	public AudioClip lazersPoweredOn;	//CHAD
	public AudioClip jesusCraigKeepItTogether;	//BRODIE
	public AudioClip goodLuckOutThereSoldier;	//CHAD


	public AudioClip powerupPickupSound;
	public AudioSource powerUpSource;
	public AudioSource doorSource;
	public AudioClip doorSound;

	//the timer is a counter we will use to determine when to show the next conversation
	int timer;


	// Use this for initialization
	void Start () {
		timer = -200;
		spriteRenderer = GetComponent<SpriteRenderer>();
		doorSource.volume = 0.35f;
		powerUpSource.volume = 0.35f;
	}

	void FixedUpdate(){
		timer += 1;
		if (timer == -100) {
			startingWords ();
		}
	}

	// Update is called once per frame
	void Update () {

		if (timer > 400) {
			timer = 0;
			Conversation ();
		}
	}

	public void PowerupPickup(int powerupType){
		
		powerUpSource.Stop ();
		powerUpSource.clip = powerupPickupSound; 
		powerUpSource.Play ();
		int rando = Random.Range (0, 2);


		if (rando == 1) {
			if (!AUDI.isPlaying) {
				spriteRenderer.sprite = sprite4;

				if (powerupType == 3) {//shield
					spriteRenderer.sprite = sprite4;
					timer = 0;
					FacePrep ();

					AUDI.Stop ();
					AUDI.clip = shieldFullPower; 
					AUDI.Play ();
				} else if (powerupType == 2) {
					spriteRenderer.sprite = sprite4;
					timer = 0;
					FacePrep ();

					AUDI.Stop ();
					AUDI.clip = lazersPoweredOn; 
					AUDI.Play ();
				} else if (powerupType == 1) {
					//	AUDI.Stop ();
					//	AUDI.clip = ; 
					//	AUDI.Play ();
				}
		
				Invoke ("FaceEnd", 2);
			}
		}

	}


	void startingWords(){

		FacePrep ();
		AUDI.Stop ();
		AUDI.clip = goodLuckOutThereSoldier; 
		AUDI.Play ();
		Invoke("FaceEnd", 2);
	}

	void Conversation(){
		//pick a face at random and one of their phrases.
		int chosen_face = Random.Range (0, 4); 
		//chosen_face = 0;
		FacePrep ();

		if (chosen_face == 0) {
			//Do face 1
			spriteRenderer.sprite = sprite2;

			//Chose a line to say

			int line_picker = Random.Range (0, 3);

			if(line_picker == 0){
				AUDI.Stop ();
				AUDI.clip = INeverLose; 
				AUDI.Play ();
				//Say line and loop till line is finished, then
			}

			else if(line_picker == 1){
				//Say line and loop till line is finished, then
				AUDI.Stop ();
				AUDI.clip = youllNeverMakeit; 
				AUDI.Play ();
				//Say line and loop till line is finished, then
			}

			else {
				//Say line and loop till line is finished, then
				AUDI.Stop ();
				AUDI.clip = takeOutTheTrash;
				AUDI.Play ();
				//Say line and loop till line is finished, then
			}

			Invoke("FaceEnd", 2);
		}	//End of face 1


		else if (chosen_face == 1) {
			//Do face 2
			spriteRenderer.sprite = sprite3;
			//Chose a line to say


			int line_picker = Random.Range (0, 2);

			if(line_picker == 0){
				AUDI.Stop ();
				AUDI.clip = hesAMadMan; 
				AUDI.Play ();
				//Say line and loop till line is finished, then

			}

			else if(line_picker == 1){
				//Say line and loop till line is finished, then
				AUDI.Stop ();
				AUDI.clip = jesusCraigKeepItTogether;
				AUDI.Play ();
				//Say line and loop till line is finished, then

			}//End of face 2

			else{
				//Say line and loop till line is finished, then
				AUDI.Stop ();
				//AUDI.clip = jesusCraigKeepItTogether; WIll become follow your heart
				AUDI.Play ();
				//Say line and loop till line is finished, then

			}//End of face 2

			Invoke("FaceEnd", 2);
		}

		else {
			//Do face 3
			spriteRenderer.sprite = sprite5;
			//Chose a line to say

			float line_picker;
			line_picker = 1.5f; //Random.Range (0, 2);

			if(line_picker < 1){
				AUDI.Stop ();
				//AUDI.clip = goFastCraig; WILL BECOME "CRAIGdonthanguponme" 
				AUDI.Play ();
				//Say line and loop till line is finished, then

			}

			else if(line_picker < 2){
				//Say line and loop till line is finished, then
				AUDI.Stop ();
				AUDI.clip = timeToTakeOutTrash;
				AUDI.Play ();
				//Say line and loop till line is finished, then

			}//End of face 4

			Invoke("FaceEnd", 2);
		}

	//	else if (chosen_face < 4) {
			//Do face 4
	//	}

		}

	void FacePrep(){
		//This function will open the door to display the face
		door.SetBool("Close", false);
		door.SetBool("Open", true);
		DoorNoise();

	}
	void DoorNoise(){

		doorSource.Stop ();
		doorSource.clip = doorSound; 
		doorSource.Play ();
	}

	void FaceEnd(){
		//This function will close the doors that display the faces
			door.SetBool("Open", false);
			door.SetBool("Close", true);
		//DoorNoise ();
	}
}
