﻿using UnityEngine;
using System.Collections;

public class Puzzle3Switch1 : MonoBehaviour {

    public PuzzleManager puzzleManager;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) {
        puzzleManager.puzzle3Switch1 = true;
    }

}
