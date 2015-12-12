using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {

	//Using the timer to destroy this object after a certain amount of time so that we don't have a buildup
	float timer;

	// Use this for initialization
	void Start () {
		//When spawned set velocity down at the same speed as all other terrain objects
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//updating each frame to update the timer
		timer += Time.deltaTime;
		if (timer >= 30f) {
			Destroy (this);
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
