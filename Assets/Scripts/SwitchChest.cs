using UnityEngine;
using System.Collections;

public class SwitchChest : MonoBehaviour {

    [SerializeField]
    Switch[] switches;
    int onCount = 0;
    MeshRenderer[] rends;
    BoxCollider col;

    // Use this for initialization
    void Start ()
    {
        rends = GetComponentsInChildren<MeshRenderer>();
        col = GetComponent<BoxCollider>();
        if (onCount != switches.Length)
        {
            foreach (MeshRenderer rend in rends)
            {
                rend.enabled = false;
            }
            col.enabled = false;
        }

        foreach (Switch switchy in switches)
        {
            switchy.OnSwitched += OnSwitched;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnSwitched(bool on)
    {
        if (on)
        {
            onCount++;
            if (onCount >= switches.Length)
            {
                foreach (MeshRenderer rend in rends)
                {
                    rend.enabled = true;
                }
                col.enabled = true;
            }
        }
        else
        {
            onCount--;
            foreach (MeshRenderer rend in rends)
            {
                rend.enabled = false;
            }
            col.enabled = false;
        }
    }
}
