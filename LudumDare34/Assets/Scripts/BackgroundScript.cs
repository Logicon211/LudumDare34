using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	float beginningYPosition;
	// Use this for initialization
	void Start () {
		beginningYPosition = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		//destroy object after it travels far enough
		if (transform.position.y < beginningYPosition - 25f) {
			transform.parent.GetComponent<LevelGenerator> ().terrainList.Remove (transform.gameObject);
			Object.Destroy (this.gameObject);
		}
	}
}
