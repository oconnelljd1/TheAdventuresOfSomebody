using UnityEngine;
using System.Collections;

public class PlatformSwitch : MonoBehaviour {


	public GameObject platform;

	public int current;

	public Transform pos1;
	public Transform pos2;
	public Transform pos3;

	void Start () {
		current = 0;
	}

	void Update () {
		if (current == 0) {
			platform.transform.position = pos1.transform.position;
		}

		if (current == 1) {
			platform.transform.position = pos2.transform.position;
		}

		if (current == 2) {
			platform.transform.position = pos3.transform.position;
		}
	}

	void OnTriggerEnter (Collider trigger) {
		if (trigger.tag == "Hitbox") {
			current++;

			if (current >= 3) {
				current = 0;
			}
		}
	}
}
