using UnityEngine;
using System.Collections;

public interface IDestroyable<T> {

	// Use this for initialization
	void kill(T killObject);
}
