using UnityEngine;
using System.Collections;

public class GP_HurtThenTeleport : MonoBehaviour {

	public Transform playerTeleportTo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Player") {
			trigger.gameObject.transform.position = playerTeleportTo.transform.position;
			trigger.gameObject.GetComponent<PlayerStats> ().Damage();
		}
	}

}
