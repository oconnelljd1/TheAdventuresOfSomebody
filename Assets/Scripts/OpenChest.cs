using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {

	//0 = blueKey, 1 = yellowKey, 2 = redKey, 3 = health, 4 = arrows
	[SerializeField]
	private int stuff;

	private Animator anim;

	private bool open;

	// Use this for initialization
	void Start () {
		open = false;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Hitbox") {
			Debug.Log ("got hit");
			if (!open) {
				Debug.Log ("opening, sorta");
				open = true;
				anim.SetTrigger ("open");
				PlayerStats myPlayerStats = trigger.gameObject.GetComponentInParent<PlayerStats> ();
				if (stuff < 3) {
					myPlayerStats.GiveKey (stuff);
				} else if (stuff == 4) {
					myPlayerStats.GiveHealth ();
				} else if (stuff == 5){
					myPlayerStats.GiveArrows ();
				} 
			}
		}
	}
}
