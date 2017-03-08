using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	[SerializeField]
	private GameObject arrowPrefab;

	[SerializeField]
	private float delay;
	[SerializeField]
	private float displacement;

	private float time;
	private float timeDelay = 2;

	// Use this for initialization
	void Start () {
		time = delay;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time + timeDelay) {
			Fire ();
			time = Time.time;
		}
	}

	private void Fire(){
		//Debug.Log ("fired");
		GameObject arrow = Instantiate (arrowPrefab, transform.position, arrowPrefab.transform.rotation) as GameObject;
		Vector3 tempP = transform.position;
		tempP.z += displacement;
		arrow.transform.position = tempP;
		Vector3 tempR = transform.eulerAngles;
		arrow.transform.eulerAngles = tempR;
	}

}
