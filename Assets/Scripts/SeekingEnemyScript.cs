using UnityEngine;
using System.Collections;

public class SeekingEnemyScript : MonoBehaviour {

	private float time;
	private float timeDelay = 1;
	private int health = 2;

	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject player;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		

		Vector3 Direction = player.transform.position - transform.position;
		RaycastHit hit;

		Debug.DrawRay (transform.position, Direction.normalized * 10, Color.red);
		if (Physics.Raycast (transform.position, Direction.normalized, out hit, 10.0f)) {
			if (hit.collider.tag == "Player") {
				//Debug.Log("seeking");
				transform.eulerAngles = new Vector3(0, Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, 0);
				float Distance = Mathf.Sqrt((Direction.x * Direction.x)+(Direction.z * Direction.z));
				if (Distance > 1) {
					transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);
				} else if (Distance < 1) {
					if (time > Time.time + timeDelay) {
						Attack ();
					}
				}
			}


			//RaycastHit hit = Physics.Raycast (transform.position, player.transform.position);

		}
	}

	void OnTriggerEnter (Collider trigger){
		if (trigger.tag == "Player") {
			trigger.gameObject.GetComponent<PlayerStats> ().Damage ();
		} else if (trigger.tag == "Hitbox") {
			health--;
			if (health == 0) {
				Object.Destroy (gameObject);
			}
		}
	}

	private void Attack(){
		
	}
}
