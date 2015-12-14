using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	public static int getScore() {
		return score;
	}

	public static void setScore(int scoreIn) {
		score = scoreIn;
	}

}
