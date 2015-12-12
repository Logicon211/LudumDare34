using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {

	//Using the timer to destroy this object after a certain amount of time so that we don't have a buildup
	private float timer;
	private float beginningYPosition;


	// Use this for initialization
	void Start () {
		//When spawned set velocity down at the same speed as all other terrain objects
		timer = 0f;
		beginningYPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		//destroy object after it travels far enough
		if (transform.position.y < beginningYPosition - 50f) {
			transform.parent.GetComponent<LevelGenerator> ().terrainList.Remove (transform.gameObject);
			Object.Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Check for player collision, blow him up and he loses or whatever

		/*Debug.Log(col.gameObject);
		IDamagable damagable = (IDamagable)col.gameObject.GetComponent(typeof(IDamagable));
		if(damagable != null) {
			GetComponent<AudioSource>().Play();
			damagable.Damage(damageAmount);
			player.ChangeHeat(-10);
		}*/
	}
}
