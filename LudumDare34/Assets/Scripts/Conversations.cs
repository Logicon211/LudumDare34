using UnityEngine;
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
	public AudioClip youreAlmostToTheCOre;
	public AudioClip craigDontHangUpOnMe;
	public AudioClip followYourHeart;

	public AudioClip powerupPickupSound;
	public AudioSource powerUpSource;
	public AudioSource doorSource;
	public AudioClip doorSound;

	private int chosen_face;

	//the timer is a counter we will use to determine when to show the next conversation
	int timer;


	// Use this for initialization
	void Start () {
		timer = -200;
		spriteRenderer = GetComponent<SpriteRenderer>();
		doorSource.volume = 0.35f;
		powerUpSource.volume = 0.35f;
		chosen_face = 4;
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
		int previous_face = chosen_face;
		Debug.Log("Previous face: " + previous_face);

		chosen_face = Random.Range (0, 3);
		Debug.Log("chosen face: " + chosen_face);

		while (chosen_face == previous_face) {
			chosen_face = Random.Range (0, 4); 

			Debug.Log("chosen face (loop): " + chosen_face);
		}

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
			}

			else if(line_picker == 1){
				AUDI.Stop ();
				AUDI.clip = youllNeverMakeit; 
				AUDI.Play ();
			}

			else {
				AUDI.Stop ();
				AUDI.clip = takeOutTheTrash;
				AUDI.Play ();
			}

			Invoke("FaceEnd", 2);
		}	//End of face 1


		else if (chosen_face == 1) {
			//Do face 2
			spriteRenderer.sprite = sprite3;

			int line_picker = Random.Range (0, 3);

			if(line_picker == 0){
				AUDI.Stop ();
				AUDI.clip = hesAMadMan; 
				AUDI.Play ();
			}

			else if(line_picker == 1){
				AUDI.Stop ();
				AUDI.clip = jesusCraigKeepItTogether;
				AUDI.Play ();
			}//End of face 2

			else{
				AUDI.Stop ();
				AUDI.clip = followYourHeart;
				AUDI.Play ();
			}//End of face 2

			Invoke("FaceEnd", 2);
		}

		else {
			//Do face 3
			spriteRenderer.sprite = sprite5;

			int line_picker = Random.Range (0, 3);

			if(line_picker < 1){
				AUDI.Stop ();
				AUDI.clip = craigDontHangUpOnMe;
				AUDI.Play ();
			}

			else if(line_picker < 2){
				AUDI.Stop ();
				AUDI.clip = timeToTakeOutTrash;
				AUDI.Play ();
			}

			else{
				AUDI.Stop ();
				AUDI.clip = youreAlmostToTheCOre;
				AUDI.Play ();
			}//End of face 4

			Invoke("FaceEnd", 2);
		}
			

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
