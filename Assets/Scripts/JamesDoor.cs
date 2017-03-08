using UnityEngine;
using System.Collections;

public class JamesDoor : MonoBehaviour {

	private GameObject door;
	private int state = 0;
	private Vector3 current;
	private Vector3 open;
	private Vector3 closed;
	private float time;

	[SerializeField]
	private GameObject[] enemies;

	[SerializeField]
	private GameObject[] switches;

	//blue = 0, yellow = 1, red = 2, rainbow = 3, no color = 4;
	[SerializeField]
	private int doorColor = 4;

	void Start(){
		door = gameObject.transform.GetChild (0).gameObject;
		closed = door.transform.eulerAngles;
		Vector3 temp = door.transform.eulerAngles;
		temp.y += 90;
		open = temp;
	}

	void Update(){
		if (state == 1) {
			door.transform.rotation = Quaternion.Lerp(Quaternion.Euler(current), Quaternion.Euler(closed), Time.time - time);
		} else if (state == 2) {
			door.transform.rotation = Quaternion.Lerp(Quaternion.Euler(current), Quaternion.Euler(open), Time.time - time);
		}

		if ((door.transform.eulerAngles.y == open.y || door.transform.eulerAngles.y == closed.y)&& state != 0) {
			state = 0;
		}
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Player") {
			if (doorColor == 4) {
				OpenDoor ();
			} else if (doorColor < 3) {
				if (trigger.gameObject.GetComponentInParent<PlayerStats> ().ReturnKey (doorColor)) {
					OpenDoor ();
				}
			} else if (doorColor == 3) {
				if(trigger.gameObject.GetComponentInParent<PlayerStats>().ReturnKey(0)){
					if(trigger.gameObject.GetComponentInParent<PlayerStats>().ReturnKey(1)){
						if(trigger.gameObject.GetComponentInParent<PlayerStats>().ReturnKey(2)){
							OpenDoor();
						}
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider trigger){
		if (trigger.tag == "Player") {
			time = Time.time;
			current = door.transform.eulerAngles;
			state = 1;
			door.GetComponent<BoxCollider>().enabled = true;
		}
			
	}

	private void OpenDoor(){
		bool alive = false;
		for (int i = 0; i < enemies.Length; i++) {
			if(enemies[i] != null){
				alive = true;
				break;
			}
		}
		for (int i = 0; i < switches.Length; i++) {
			if (switches [i].GetComponent<JamesSwitch> ().GetOn () == false) {
				alive = true;
				break;
			}
		}
		if (!alive) {
			state = 2;
			time = Time.time;

			current = door.transform.eulerAngles;
			door.GetComponent<BoxCollider>().enabled = false;
		}

	}
}
