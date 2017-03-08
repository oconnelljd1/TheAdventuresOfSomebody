using UnityEngine;
using System.Collections;

public class GenericEnemy : MonoBehaviour {

    [SerializeField]
	private GameObject player;

	//private float timeDelay = 1;
	private int health = 2;
    private bool chasing;

	// Use this for initialization
	void Start () {
        chasing = false;
	}

    // Update is called once per frame
    void Update () {
	    if (chasing) {
			Vector3 Direction = player.transform.position - transform.position;
			RaycastHit hit;
			if (Physics.Raycast (transform.position, Direction.normalized, out hit, 10.0f)) {
				if (hit.collider.tag == "Player") {
					transform.eulerAngles = new Vector3(0, Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, 0);
					transform.Translate (Vector3.forward * Time.deltaTime * 2);
				}
			}else{
				chasing = false;
			}
        }
	}

    //The enemy will chase the player when they enter their radius.
    void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Player") {
			trigger.gameObject.GetComponent<PlayerStats> ().Damage ();
		} else if (trigger.tag == "Hitbox") {
			chasing = true;
			health--;
			Debug.Log (health);
			if (health == 0) {
				Object.Destroy (gameObject);
			}
		}
    }
}
