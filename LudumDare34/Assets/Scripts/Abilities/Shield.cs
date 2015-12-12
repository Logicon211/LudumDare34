using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	
	public int abilityId = 1;
	Ship ship;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Debug.Log("Fuck");
			ship = coll.gameObject.GetComponent<Ship>();
			ship.setShield();
			Destroy(gameObject);
		}
	}
}
