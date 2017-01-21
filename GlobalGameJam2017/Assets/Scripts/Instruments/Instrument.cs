using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {
    public Projectile Note;
    public float NormalDamage;
    public float DamageMuilty;
	// Use this for initialization
	void Start () {	
	}
	// Update is called once per frame
	void Update () {
	}
    public virtual void Attack(Vector3 Direction) { }
    public virtual void AggroLight() { }
    public virtual void AggroHeavy() { }
    public virtual void Utility() { }
    public virtual void Defense() { }
}
