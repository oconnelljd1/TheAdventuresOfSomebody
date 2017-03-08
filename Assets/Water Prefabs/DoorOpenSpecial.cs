using UnityEngine;
using System.Collections;

public class DoorOpenSpecial : MonoBehaviour {

    //Create an empty GameObject and place it in the centre of your door's hinge. Now child the door to the empty GameObject.
    //Attach this script to the empty GameObject.
    //You can edit this script to fit all sort of doors, such as trapdoors, the tops of treasure chests, and objects that swing down using hinges. 

    private bool opening, closing, closed;

    public Transform playerLoc;

    private float rotateSpeed;

    public bool locked;

    void Start() {
        //Be careful of the closed variable. Make sure to set it to false if the door is open by default.
        locked = true;
        closed = true;
        opening = false;
        closing = false;
        rotateSpeed = 40.0f;
    }

    // Update is called once per frame
    void Update() {
        

        //door rotates slightly every frame while opening or closing until it is complete
        if (opening) {
            //0.80 (80 degrees) was used her instead of 0.90 in order to avoid going over.
            if (transform.localRotation.y < 0.80f) {
                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            } else {
                opening = false;
                closed = false;
            }
        } else if (closing) {
            if (transform.localRotation.y > 0.0f) {
                transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
            } else {
                closing = false;
                closed = true;
            }
        }
        

    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            //Activates when the player is nearby. Nothing will happen if the door is already in action.
            if (!locked && opening == false && closing == false) {
                //opens or closes the door depending on whether or not it is already closed.
                if (closed) {
                    opening = true;
                } else {
                    closing = true;
                }
            }

        }
    }

}
