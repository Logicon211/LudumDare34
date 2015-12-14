using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour {
	public int score;
	public Text scoreText;
	public Ship player;

	// Use this for initialization
	void Start () {
		ScoreManager.setScore(0);
		scoreText.text = ScoreManager.getScore().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ScoreManager.getScore().ToString ();
	}

	void FixedUpdate(){
		if (!player.isDead) {
			ScoreManager.setScore(ScoreManager.getScore() + 1);
		}
	}

	public void addScore(int scoreIn){
		score += scoreIn;
	}

}
