using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Guitar : Instrument {
    public GameObject Amp, droppedAmp;
    public GameObject ShockWave;
    Transform AmpPos;
    public bool AmpDropped;
    
    // Use this for initialization
    void Start () {
        //set up normal attack note
        //Amp.GetComponent<Renderer>().enabled = false;
     
        AmpPos = gameObject.transform;
    }

    // Update is called once per frame
    public override void Update () {
        base.Update();


    }

    public override void Attack(Vector3 Direction) {
        if (AttackCoolDownWait <= 0)
        {
            AttackCoolDownWait = AttackCoolDown;
            GameObject inst = new GameObject();
            if (!AmpDropped)
                inst = Instantiate(Note[0], this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.AngleAxis(Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, Vector3.up));
            else
                inst = Instantiate(Note[0], AmpPos.position, Quaternion.AngleAxis(Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, Vector3.up));

            inst.GetComponent<Rigidbody>().velocity = Direction * velocity;
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.owner = gameObject.transform.parent.gameObject);
        }
    }
    public override void AggroLight(Vector3 Direction) {
        if (AggroLightCoolDownWait <= 0)
        {
            AggroLightCoolDownWait = AggroLightCoolDown;
            GameObject inst = new GameObject();
            if (!AmpDropped)
                inst = Instantiate(Note[1], this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.AngleAxis(Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, Vector3.up));
            else
                inst = Instantiate(Note[1], AmpPos.position, Quaternion.AngleAxis(Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg, Vector3.up));
            inst.GetComponent<Rigidbody>().velocity = Direction * velocity;
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.owner = gameObject.transform.parent.gameObject);
        }
    }
    public override void AggroHeavy(Vector3 Direction) {
        base.AggroHeavy(Direction);
        if (AggroHeavyCoolDownWait <= 0) {
            AggroHeavyCoolDownWait = AggroHeavyCoolDown;
            GameObject shockWave = Instantiate(ShockWave, transform.position, transform.rotation) as GameObject;
            shockWave.transform.Rotate(-90 , 0, 0);
            shockWave.GetComponent<Rigidbody>().velocity = Direction * velocity;
        }
    }
    public override void Utility(Vector3 Direction) {
        if (UtilityCoolDownWait <= 0)
        {
            UtilityCoolDownWait = UtilityCoolDown;
            if (AmpDropped == false)
            {
                //GameObject DroppedAmp = Amp;
                AmpDropped = true;
                //DroppedAmp.GetComponent<Amp>().Dropped(true);
                droppedAmp = Instantiate(Amp, transform.position, transform.rotation) as GameObject;
                droppedAmp.GetComponent<Amp>().Dropped(true);
                AmpPos = droppedAmp.transform;
            }
            else if (AmpDropped) {
                AmpPos = transform;
               Destroy(droppedAmp);
                AmpDropped = false;
            }
        }
    }
    public override void Defense(Vector3 Direction) {
        if (DefenseCoolDownWait <= 0) {
            DefenseCoolDownWait = DefenseCoolDown;
        } 
    }
}
