using UnityEngine;
using System.Collections;

public class GetKeyFromChest : MonoBehaviour {

    public KeyManager keyManager;
    //Colour of key in chest. Blue is 0, yellow is 1, red is 2.
    public int colour;

    public bool opened;

    public AudioSource puzzleSolved;

	// Use this for initialization
	void Start () {
        opened = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision col) {
        if (!opened) {
            if (col.gameObject.CompareTag("Player")) {
                if (colour == 0) {
                    keyManager.blue = true;
                    opened = true;
                    puzzleSolved.Play();
                }
                if (colour == 1) {
                    keyManager.yellow = true;
                    opened = true;
                    puzzleSolved.Play();
                }
                if (colour == 2) {
                    keyManager.red = true;
                    opened = true;
                    puzzleSolved.Play();
                }
            }
        }
    }

}
