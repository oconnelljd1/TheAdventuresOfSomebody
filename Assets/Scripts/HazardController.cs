using UnityEngine;
using System.Collections;

public class HazardController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Player") {
			trigger.gameObject.GetComponent<PlayerStats> ().Damage();
		}
	}

}
