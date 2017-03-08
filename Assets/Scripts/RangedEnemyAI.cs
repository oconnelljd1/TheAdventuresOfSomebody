using UnityEngine;
using System.Collections;

public class RangedEnemyAI : MonoBehaviour {

	private float time;
	private float timeDelay = 1;
	private int health = 2;
	private float Distance = 1.25f;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject arrowPrefab;

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
				Debug.Log("seeking");
				transform.eulerAngles = new Vector3(0, Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, 0);
				if (Time.time > time + timeDelay) {
					Debug.Log ("Attack");
					time = Time.time;
					Attack ();
				}
			}
		}
	}

	void OnTriggerEnter(Collider trigger){
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
		Debug.Log ("Fired");
		GameObject arrow = Instantiate (arrowPrefab, transform.position, arrowPrefab.transform.rotation) as GameObject;
		Vector3 TempR = arrow.transform.eulerAngles;
		TempR.y = transform.eulerAngles.y;
		arrow.transform.eulerAngles = TempR;
		Vector3 TempP = arrow.transform.position;
		TempP.x += Mathf.Sin (transform.eulerAngles.y * Mathf.Deg2Rad) * Distance;
		TempP.z += Mathf.Cos (transform.eulerAngles.y * Mathf.Deg2Rad) * Distance;
		arrow.transform.position = TempP;
	}
}
