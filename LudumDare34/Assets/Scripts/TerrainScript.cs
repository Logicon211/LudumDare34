using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//When spawned set velocity down at the same speed as all other terrain objects
	}
	
	// Update is called once per frame
	void Update () {
		//I don't think we need to update velocity each frame but I'm not sure
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
