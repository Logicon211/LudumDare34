using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour {
	public int score;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString ();
	}

	void FixedUpdate(){
		score += 1;
	}

	public void addScore(int scoreIn){
		score += scoreIn;
	}

}
