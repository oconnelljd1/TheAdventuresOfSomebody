using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour {

	//public static ScreenManager instance;
	private bool[] myLocks = new bool[4];

	[SerializeField]
	private GameObject[] locks = new GameObject[4];

	// Use this for initialization
	void Start () {
		ProgressManager.instance.Init ();
		myLocks = ProgressManager.instance.GetLocks ();
		for (int i = 0; i < 4; i++) {
			locks [i].SetActive (myLocks [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void Cheat(){
		for(int i = 0; i < 4; i++){
			locks[i].SetActive(false);
		}
	}

	public void UnlockADoor(int door){
		locks [door].SetActive (false);
	}

	public void LoadLevel(){
		SceneManager.LoadScene ("GP_JungleDungeon");
	}

	public void LoadLeve2(){
		SceneManager.LoadScene ("Earth");
	}

	public void LoadLeve3(){
		SceneManager.LoadScene ("Water");
	}

	public void LoadLeve4(){
		SceneManager.LoadScene ("JamesO2");
	}

	public void LoadLeve5(){
		SceneManager.LoadScene ("Sky");
	}
}

