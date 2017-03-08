using UnityEngine;
using System.Collections;

public class ChargingEnemyAI : MonoBehaviour {

	private bool charging;
	private Vector3 initial;
	private Vector3 changed;
	private int health = 2;
	private float time;

	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		charging = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(charging){
			transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);
		}else if(!charging){
			transform.rotation = Quaternion.Lerp (Quaternion.Euler(initial), Quaternion.Euler (changed), Time.time - time);
			if (transform.eulerAngles.y == changed.y) {
				charging = true;
			}
		}
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "TurnAround") {
			time = Time.time;
			charging = false;
			initial = transform.eulerAngles;
			Vector3 temp = initial;
			if (initial.y < 180) {
				temp.y += 180;
			} else if (initial.y >= 180) {
				temp.y -=180;
			}
			changed = temp;
		} else if (trigger.tag == "Player") {
			trigger.gameObject.GetComponent<PlayerStats> ().Damage ();
		} else if (trigger.tag == "Hitbox") {
			health--;
			if (health == 0) {
				Object.Destroy (gameObject);
			}
		}
	}
}
