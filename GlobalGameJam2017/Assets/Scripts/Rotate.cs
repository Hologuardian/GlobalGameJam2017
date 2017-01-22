using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float seed;
    float speed = 0.5f;
    public bool flip = false;
    private bool pause = false;
	// Use this for initialization
	void Start ()
    {
        seed = 0;// Random.value;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!pause)
		    transform.localRotation = Quaternion.AngleAxis((flip ? -1 : 1) * (Mathf.PingPong(Time.time * speed + seed, Mathf.PI / 3) - Mathf.PI / 6) * Mathf.Rad2Deg, Vector3.up);
    }

    public void Pause(bool p)
    {
        if(p)
            transform.localRotation = Quaternion.AngleAxis(((flip ? -1 : 1) * (-Mathf.PI / 6f)) * Mathf.Rad2Deg, Vector3.up);
        pause = p;
    }
}
