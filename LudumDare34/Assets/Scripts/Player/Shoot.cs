using UnityEngine;
using System.Collections;

//In charge of controlling the bullets
//Mitch named this class
public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);

	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		IDestroyable damagable = (IDestroyable)col.gameObject.GetComponent(typeof(IDestroyable));
		if(damagable != null) {
			damagable.kill();
			Object.Destroy(this.gameObject);
		}
	}
}