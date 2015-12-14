using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	private string highScoreKey = "highScore";

	private int highScore;

	// Use this for initialization
	void Start () {
		scoreText.text = ScoreManager.getScore().ToString ();

		highScore = PlayerPrefs.GetInt (highScoreKey, 0);

		if (ScoreManager.getScore() > highScore) {
			highScore = ScoreManager.getScore ();
			PlayerPrefs.SetInt(highScoreKey, highScore);
		}

		highScoreText.text = highScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ScoreManager.getScore().ToString ();
		highScoreText.text = highScore.ToString ();
	}
}
