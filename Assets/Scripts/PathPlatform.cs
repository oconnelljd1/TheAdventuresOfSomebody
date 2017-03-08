using UnityEngine;
using System.Collections;

public class PathPlatform : MonoBehaviour {

    public Transform[] waypoints;
    public float speed;

    int currentWaypoint = 0;
    Vector3 direction;

    // Use this for initialization
    void Start ()
    {
        direction = waypoints[currentWaypoint].position - transform.position;
        direction = direction.normalized;
    }
    
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Waypoint")
        {
            currentWaypoint++;

            if (currentWaypoint > waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }

            direction = waypoints[currentWaypoint].position - transform.position;
            direction = direction.normalized;
        }
    }
}
