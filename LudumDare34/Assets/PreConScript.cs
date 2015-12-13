using UnityEngine;
using System.Collections;

public class PreConScript : MonoBehaviour {

	private float beginningYPosition;
	// Use this for initialization
	void Start () {
		Transform top = transform.FindChild ("TopOfPreCon");
		if (top != null) {
			beginningYPosition = top.position.y;	
		} else {
			beginningYPosition = transform.position.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < beginningYPosition - 50f) {
			if (transform.parent != null) {
				transform.parent.GetComponent<LevelGenerator> ().preConList.Remove (transform.gameObject);
				Object.Destroy (this.gameObject);
			}
		}
	}
}
