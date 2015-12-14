using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = ScoreManager.getScore().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ScoreManager.getScore().ToString ();
	}
}
