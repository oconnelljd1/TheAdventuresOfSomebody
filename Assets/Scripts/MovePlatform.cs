using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

    //Attach this script to your platform. Your platform should be set in the centre of its path.
    //You can change the distance and speed using the multipliers below.
    //You can also limit the movement of the platform using movingX, movingZ, and movingY.

    public float maxDistance, speed;

    public bool movingX, movingZ, movingY;

	[SerializeField]
	private float offset = 0;

    private Vector3 newPosition;

	//You can remove the initialization for the first five if you wish and set your variables up in Unity's inspector. 
	void Start () {
		/*
        maxDistance = 1.0f;
        speed = 1.0f;
        movingX = true;
        movingZ = true;
        movingY = true;
        */
        newPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        //This moves the platform right then left. 
        if (movingX) {
			Vector3 temp = newPosition;
			temp.x = newPosition.x + (maxDistance * Mathf.Sin((Time.time * speed)+offset));
            //newPosition.x = (maxDistance * Mathf.Sin(Time.time * speed));
            transform.localPosition = temp;
        }
        //This moves the platform forwards then backwards.
        if (movingZ) {
			Vector3 temp = newPosition;
			temp.z = newPosition.z + (maxDistance * Mathf.Sin((Time.time * speed)+offset));
			//newPosition.x = (maxDistance * Mathf.Sin(Time.time * speed));
			transform.localPosition = temp;
        }
        //This moves the platform up then down. 
        if (movingY) {
			Vector3 temp = newPosition;
			temp.y = newPosition.y + (maxDistance * Mathf.Sin((Time.time * speed)+offset));
			//newPosition.x = (maxDistance * Mathf.Sin(Time.time * speed));
			transform.localPosition = temp;
        }
    }
}
