using UnityEngine;
using System.Collections;

public class Puzzle2Switch4 : MonoBehaviour {

    public PuzzleManager puzzleManager;
    public Puzzle2Switch1 p2S1;
    public Puzzle2Switch2 p2S2;
    public Puzzle2Switch3 p2S3;

    public AudioSource puzzleFail;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        if (puzzleManager.puzzle2Switch1 && puzzleManager.puzzle2Switch2 && puzzleManager.puzzle2Switch3) {
            puzzleManager.puzzle2Switch4 = true;
        }
        else {
            //Reset puzzle
            puzzleFail.Play();
            puzzleManager.puzzle2Switch1 = false;
            puzzleManager.puzzle2Switch2 = false;
            puzzleManager.puzzle2Switch3 = false;
            puzzleManager.puzzle2Switch4 = false;
        }
    }

}
