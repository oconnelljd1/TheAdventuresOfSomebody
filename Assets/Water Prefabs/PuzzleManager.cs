using UnityEngine;
using System.Collections;

public class PuzzleManager : MonoBehaviour {

    //Switch bools.
    public bool puzzle1Switch1, puzzle1Switch2, puzzle1Switch3;
    public bool puzzle2Switch1, puzzle2Switch2, puzzle2Switch3, puzzle2Switch4;
    public bool puzzle3Switch1, puzzle3Switch2, puzzle3Switch3, puzzle3Switch4;
    public bool doorSwitch;

    //Puzzle solved bools.
    public bool puzzle1Solved, puzzle2Solved, puzzle3Solved, puzzle4Solved;

    //Objects to reference.
    public DoorOpenSpecial doorLockedBySwitches;
    public DoorOpenSpecial doorLockedBySwitches2;
    public DoorOpenSpecial doorLockedByPressurePlate;
    public MovePlatform movingPlatform1;

    //Audio
    public AudioSource puzzleSuccess;
    


    // Use this for initialization
    void Start () {
        //Set all switches to initially disactivated. 
	    puzzle1Switch1 = false;
        puzzle1Switch2 = false;
        puzzle1Switch3 = false;
        puzzle2Switch1 = false;
        puzzle2Switch2 = false;
        puzzle2Switch3 = false;
        puzzle2Switch4 = false;
        puzzle3Switch1 = false;
        puzzle3Switch2 = false;
        puzzle3Switch3 = false;
        puzzle3Switch4 = false;
        doorSwitch = false;
        puzzle1Solved = false;
        puzzle2Solved = false;
        puzzle3Solved = false;
        puzzle4Solved = false;
    }

    // Update is called once per frame
    void Update() {
        //When all the switches are pressed, do the appropriate thing once.
        if (!puzzle1Solved) {
            if (puzzle1Switch1 && puzzle1Switch2 && puzzle1Switch3) {
                movingPlatform1.movingZ = true;
                puzzleSuccess.Play();
                puzzle1Solved = true;
            }
        }
        if (!puzzle2Solved) {
            if (puzzle2Switch1 && puzzle2Switch2 && puzzle2Switch3 && puzzle2Switch4) {
                doorLockedBySwitches.locked = false;
                puzzleSuccess.Play();
                puzzle2Solved = true;
            }
        }
        if (!puzzle3Solved) {
            if (puzzle3Switch1 && puzzle3Switch2 && puzzle3Switch3 && puzzle3Switch4) {
                doorLockedBySwitches2.locked = false;
                puzzleSuccess.Play();
                puzzle3Solved = true;
            }
        }
        if (!puzzle4Solved) {
            if (doorSwitch) {
                doorLockedByPressurePlate.locked = false;
                puzzleSuccess.Play();
                puzzle4Solved = true;
            }
        }
    }
    
   
    
}
