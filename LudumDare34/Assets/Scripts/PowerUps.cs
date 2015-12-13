using UnityEngine;
using System.Collections;
public class PowerUps : MonoBehaviour {

	public int abilityId = 1;
	public Ship ship;

	float beginningYPosition;

	// Use this for initialization
	void Start () {
		beginningYPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < beginningYPosition - 25f) {
			transform.parent.GetComponent<LevelGenerator> ().terrainList.Remove (transform.gameObject);
			Object.Destroy (this.gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			ship = coll.gameObject.GetComponent<Ship>();
			givePowerUp();
			Destroy(gameObject);
		}
	}

	virtual protected void givePowerUp() {
		//Do something
	}
}
