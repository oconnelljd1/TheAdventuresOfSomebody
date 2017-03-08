using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public delegate void Switched(bool on);
    public event Switched OnSwitched;

    public enum Type {Switch,Button,PressurePlate};
    public Type type;

    bool on = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        switch (type)
        {
            case Type.Switch:
                if (col.tag == "Hitbox")
                {
                    if (on)
                        on = false;
                    else
                        on = true;

                    OnSwitched(on);
                }
                break;

            case Type.PressurePlate:
                //if (col.tag == "Player")
                //{
                //    if (!on)
                //        on = true;

                //    OnSwitched(on);
                //}

                if (col.tag == "Pushable")
                {
                    if (!on)
                        on = true;

                    OnSwitched(on);
                }
                break;

            case Type.Button:
                if (col.tag == "Player" || col.tag == "Pushable")
                {
                    if (!on)
                        on = true;

                    OnSwitched(on);
                }
                break;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (type == Type.PressurePlate)
        {
            if(col.tag == "Pushable")
            {
                if (on)
                    on = false;

                OnSwitched(on);
            }
        }
    }
}
