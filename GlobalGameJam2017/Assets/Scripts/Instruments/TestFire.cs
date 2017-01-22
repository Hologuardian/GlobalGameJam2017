using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFire : MonoBehaviour {
    public Projectile Note;
    public float coolDown,waitTime;
    // Use this for initialization
    void Start () {
        waitTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waitTime = coolDown;
            Projectile note = new Projectile();
            print(transform.rotation);
            note = Instantiate(Note, this.transform.position, this.transform.rotation);
            note.GetComponent<Rigidbody>().velocity = transform.forward*2;
            Destroy(note.gameObject, 1f);
            Destroy(note, 1f);
        }
    }
}
