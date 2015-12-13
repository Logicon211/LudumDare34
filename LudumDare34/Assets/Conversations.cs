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
	public AudioClip goodLuckOutThere;
	public AudioClip hesAMadMan;
	public AudioClip INeverLose;
	public AudioClip shieldFullPower;
	public AudioClip takeOutTheTrash;
	public AudioClip timeToTakeOutTrash;
	public AudioClip youllNeverMakeit;

	//the timer is a counter we will use to determine when to show the next conversation
	int timer;


	// Use this for initialization
	void Start () {
		timer = -200;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate(){
		timer += 1;
	}

	// Update is called once per frame
	void Update () {

		if (timer > 400) {
			timer = 0;
			Conversation ();
		}
	}

		void Conversation(){
		//pick a face at random and one of their phrases.
		float chosen_face;
		//chosen_face = Random.Range (0, 4); 
		chosen_face = 0;
		FacePrep ();

		if (chosen_face < 1) {
			//Do face 1
			spriteRenderer.sprite = sprite2;

			//Chose a line to say

			float line_picker;
			//line_picker = Random.Range (0, 2);
			line_picker =0;


			if(line_picker < 1){
				AUDI.Stop ();
				AUDI.clip = INeverLose; 
				AUDI.Play ();
				//Say line and loop till line is finished, then
			
				Invoke("FaceEnd", 2);

			}

			else if(line_picker < 2){
				//Say line and loop till line is finished, then
				AUDI.Stop ();
				AUDI.clip = youllNeverMakeit; 
				AUDI.Play ();
				//Say line and loop till line is finished, then

				Invoke("FaceEnd", 2);
			}

		}	//End of face 1


		else if (chosen_face < 2) {
			//Do face 2
		}

		else if (chosen_face < 3) {
			//Do face 3
		}

		else if (chosen_face < 4) {
			//Do face 4
		}

		}

	void FacePrep(){
		//This function will open the door to display the face
		door.SetBool("Open", true);
		door.SetBool("Close", false);

	}

	void FaceEnd(){
		//This function will close the doors that display the faces
			door.SetBool("Open", false);
			door.SetBool("Close", true);
	}
}