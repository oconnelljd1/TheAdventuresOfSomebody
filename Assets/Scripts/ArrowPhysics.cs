using UnityEngine;
using System.Collections;

public class ArrowPhysics : MonoBehaviour {

	public int arrowSpeed = 1;

	void Update () {
		transform.Translate (transform.up * Time.deltaTime * arrowSpeed, Space.World);
	}

	void OnCollisionEnter (Collision col) {
		//Debug.Log (col.collider.name);
		Destroy (gameObject);
	}
}
