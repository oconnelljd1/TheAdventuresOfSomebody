using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

   
    public Transform pl;
    public Transform targetPosition;

    //Play water sound if the switch is a water level changer.
    public bool water;
    public AudioSource waterSound;

    void Start () {
        
    }

	void OnTriggerEnter (Collider col) {
        if (col.gameObject.tag == "Player") {
            //Move the player to an assigned platform.
            pl.transform.position = new Vector3(targetPosition.transform.position.x, targetPosition.transform.position.y + 2, targetPosition.transform.position.z);
            if (water) {
                
                waterSound.Play();
            }
        }
    }
}
