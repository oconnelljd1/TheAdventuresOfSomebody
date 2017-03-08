using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour {

	public static ProgressManager instance;

	private bool[] locks = new bool[4];

	private bool loaded = false;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
		}
	}

	void MakeSingleton() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public bool[] GetLocks(){
		return locks;
	}

	public void UnlockLocK(int aaa){
		locks [aaa] = false;
		SceneManager.LoadScene ("Overworld");
	}

	public void Init(){
		if (!loaded) {
			loaded = true;
			for (int i = 0; i < 4; i++) {
				locks [i] = true;
			}
		}
	}

}
