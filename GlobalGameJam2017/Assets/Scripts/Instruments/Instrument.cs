using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class Instrument : MonoBehaviour {
    public GameObject[] Note;
    public float AttackCoolDownWait, AggroLightCoolDownWait, AggroHeavyCoolDownWait, UtilityCoolDownWait, DefenseCoolDownWait;
    public float AttackCoolDown, AggroLightCoolDown, AggroHeavyCoolDown, UtilityCoolDown, DefenseCoolDown;
    public float velocity;
    public float waitTime;
    public float Damage = 1.0f;
    // Use this for initialization
    void Start () {	
	}
	// Update is called once per frame
	public virtual void Update () {
        if (AttackCoolDownWait > 0)
            AttackCoolDownWait -= Time.deltaTime;
        if (AggroLightCoolDownWait > 0)
            AggroLightCoolDownWait -= Time.deltaTime;
        if (AggroHeavyCoolDownWait > 0)
            AggroHeavyCoolDownWait -= Time.deltaTime;
        if (UtilityCoolDownWait > 0)
            UtilityCoolDownWait -= Time.deltaTime;
        if (DefenseCoolDownWait > 0)
            DefenseCoolDownWait -= Time.deltaTime;
    }
    public virtual void Attack(Vector3 Direction) {
        if (AttackCoolDownWait < 0) {
            AttackCoolDownWait = AttackCoolDown;
        }
        return;
    }
    public virtual void AggroLight(Vector3 Direction) { }
    public virtual void AggroHeavy(Vector3 Direction) { }
    public virtual void Utility(Vector3 Direction) { }
    public virtual void Defense(Vector3 Direction) { }
}
