using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	[SerializeField]
	private float force;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider trigger){
		if(trigger.tag == "Player"){
			trigger.gameObject.transform.Translate(Vector3.left * force * Time.deltaTime);
		}
	}
}
