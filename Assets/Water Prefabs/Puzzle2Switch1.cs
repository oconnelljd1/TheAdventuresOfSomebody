using UnityEngine;
using System.Collections;

public class Puzzle2Switch1 : MonoBehaviour {

    public PuzzleManager puzzleManager;
    public Puzzle2Switch2 p2S2;
    public Puzzle2Switch3 p2S3;
    public Puzzle2Switch4 p2S4;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        puzzleManager.puzzle2Switch1 = true;
    }

}
