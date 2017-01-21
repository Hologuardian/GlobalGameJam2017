using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : Instrument {
    public GameObject Amp;
    public bool AmpDropped;

    // Use this for initialization
    void Start () {
        //set up normal attack note
        //Amp.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (AmpDropped) {
            
        }
	}

    public override void Attack(Vector3 Direction) {
        if (!AmpDropped)
        {
            Instantiate(Note,transform.position, transform.rotation);
        }
        else {
            Instantiate(Note, Amp.transform.position, Amp.transform.rotation);
        }
    }
    public override void AggroLight() { }
    public override void AggroHeavy() { }
    public override void Utility() {
        if (AmpDropped == false)
        {
            //GameObject DroppedAmp = Amp;
            AmpDropped = true;
            //DroppedAmp.GetComponent<Amp>().Dropped(true);
            Amp amp = Instantiate(Amp, transform.position, transform.rotation).GetComponent<Amp>();
            amp.Dropped(true);
            Amp = amp.GetComponent<GameObject>();
        }
    }
    public override void Defense() {
       
    }
}
