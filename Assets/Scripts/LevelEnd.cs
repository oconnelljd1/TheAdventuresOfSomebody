using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	[SerializeField]
	private int thisLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Player") {
			ProgressManager.instance.UnlockLocK(thisLevel - 1);
		}
	}

}
