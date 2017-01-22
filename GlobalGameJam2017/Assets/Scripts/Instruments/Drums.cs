using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drums : Instrument
{
    float attackTime, mainAttackTime;
    public float AttackCoolDown, AggroLightCoolDown, AggroHeavyCoolDown, UtilityCoolDown, DefenseCoolDown;
    // Use this for initialization
    void Start()
    {
        //set up normal attack note
        //Amp.GetComponent<Renderer>().enabled = false;
        attackTime = 0;
        AttackCoolDown = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime > 0)
        {
            attackTime -= Time.deltaTime;
        }
        if (mainAttackTime > 0)
        {
            mainAttackTime -= Time.deltaTime;
        }
    }

    public override void Attack(Vector3 Direction)
    {
        if (mainAttackTime <= 0)
        {
            GameObject note = new GameObject();
            note = Instantiate(Note[0], transform.position, transform.rotation);
            mainAttackTime = AttackCoolDown;
        }
    }
    public override void AggroLight(Vector3 Direction)
    {
        if (attackTime < 0)
        {
        }
    }
    public override void AggroHeavy(Vector3 Direction) { }
    public override void Utility(Vector3 Direction)
    {
    }
    public override void Defense(Vector3 Direction)
    {

    }
}
