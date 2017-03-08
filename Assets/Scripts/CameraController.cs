using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform target;

	// Update is called once per frame
	void Update () {
        //Makes the camera follow the player.
        float tempX = target.transform.position.x;
        float tempY = target.transform.position.y;
        float tempZ = target.transform.position.z;
        transform.position = new Vector3(tempX, tempY + 10, tempZ);
    }
}
