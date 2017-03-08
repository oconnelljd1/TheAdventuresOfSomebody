using UnityEngine;
using System.Collections;

public class SwitchPlatform : MonoBehaviour {

    [SerializeField]
    Switch[] switches;
    [SerializeField]
    int speed;
    int onCount = 0;
    [SerializeField]
    Vector3 targetLocation;
    Vector3 startLocation;
    bool onOff = false;

    public bool enemy = false;

    [SerializeField]
    private GameObject[] enemies;

    // Use this for initialization
    void Start ()
    {
        foreach (Switch switchy in switches)
        {
            switchy.OnSwitched += OnSwitched;
        }
        startLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemy)
        {
            bool alive = false;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    alive = true;
                    break;
                }
            }
            if (!alive)
            {
                onOff = true;
            }
        }

        if (onOff && transform.position != targetLocation)
        {
            transform.Translate((targetLocation-transform.position).normalized * Time.deltaTime * speed);
        }
        else if (!onOff && transform.position != startLocation)
        {
            transform.Translate((startLocation - transform.position).normalized * Time.deltaTime * speed);
        }
	}

    void OnSwitched(bool on)
    {
        if (on)
        {
            onCount++;
            if (onCount >= switches.Length)
            {
                onOff = true;
            }
        }
        else
        {
            onCount--;
            onOff = false;
        }
    }
}
