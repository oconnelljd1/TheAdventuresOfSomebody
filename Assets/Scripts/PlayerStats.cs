using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	private int health;
	private int arrows;

	//bool0 = blue, bool1 = yellow, bool 2 = red
	[SerializeField]
	private bool[] keys = new bool[3];

	[SerializeField]
	private Text healthDisplay;

	// Use this for initialization
	void Start () {
		health = 3;
		for (int i = 0; i < 3; i++) {
			keys [i] = false;
		}
		healthDisplay.text = "" + health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Damage(){
		Debug.Log ("damage");
		health--;
		if (health == 0) {
			SceneManager.LoadScene ("Overworld");
		}
		healthDisplay.text = "" + health;
	}

	public void GiveKey (int index) {
		keys [index] = true;
	}

	public bool ReturnKey(int index){
		return keys [index];
	}

	public void GiveHealth(){
		if (health < 3) {
			health++;
		}
	}

	public void GiveArrows(){
		arrows += 10;
	}

}
