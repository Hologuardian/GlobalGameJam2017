using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour {
    public int MaxLife;
	// Use this for initialization
	void Start () {
        Destroy(this, MaxLife);
        Destroy(this.gameObject, MaxLife);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localScale += new Vector3(Time.deltaTime*2, Time.deltaTime*2, 0);
	}
}
