using UnityEngine;
using System.Collections;

public class JamesSwitch : MonoBehaviour {

	private bool on;

	// Use this for initialization
	void Start () {
		on = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Hitbox") {
			Debug.Log ("hitswitch");
			on = true;
		}
	}

	public bool GetOn(){
		Debug.Log (on);
		return on;	
	}

}
