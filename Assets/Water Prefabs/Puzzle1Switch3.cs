using UnityEngine;
using System.Collections;

public class Puzzle1Switch3 : MonoBehaviour {

    public PuzzleManager puzzleManager;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision col) {
        puzzleManager.puzzle1Switch3 = true;
    }

}
