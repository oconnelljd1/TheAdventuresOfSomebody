using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public PuzzleManager puzzleManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            puzzleManager.doorSwitch = true;
        }
    }
}
