using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Speaker : MonoBehaviour
{
    public GameObject basicAttack;
    public GameObject chargeAttack;
    public GameObject chargeAttack2;
    public GameObject deadlyAttack;
    public GameObject deadlyAttack2;
    public Rotate rotator;
    public float velocity;
    public float chargeVelocity;
    public float Damage = 1.0f;
    public float chargeDamage = 2.0f;
    public float deadlyDamage = 5.0f;
    public float coolDown;
    public float shotDown;
    public int shotCount = 6;
    public float chargeDown;
    public float deadlyDown;
    public float deadlyDuration;
    public float deadlyShotDown;

    private float waitTime;
    private float chargeTime;
    private float deadlyTime;
    private float shotTime;
    private int shot = 0;
    private float deadlyLength = 0;
    private float deadlyShotTime = 0;

    // Use this for initialization
    void Start()
    {
        waitTime = coolDown;
        chargeTime = chargeDown;
        deadlyTime = deadlyDown;
    }

    // Update is called once per frame
    void Update()
    {
        deadlyTime -= Time.deltaTime;
        if (deadlyTime <= 0)
        {
            rotator.Pause(true);
            if (deadlyLength <= deadlyDuration)
            {
                deadlyShotTime -= Time.deltaTime;
                deadlyLength += Time.deltaTime;
                if (deadlyShotTime < 0)
                {
                    deadlyShotTime += deadlyShotDown;
                    GameObject inst = Instantiate(deadlyAttack, this.transform.position, transform.rotation);
                    inst.GetComponent<Rigidbody>().velocity = inst.transform.forward * 2f;
                    inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = deadlyDamage);

                    GameObject inst2 = Instantiate(deadlyAttack2, this.transform.position, transform.rotation);
                    inst2.GetComponent<Rigidbody>().velocity = inst2.transform.forward * 2f;
                    inst2.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = deadlyDamage);
                }
            }
            else
            {
                deadlyTime = deadlyDown;
                deadlyLength = 0;
            }
        }
        else
        {
            rotator.Pause(false);
            waitTime -= Time.deltaTime;
            chargeTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                shotTime -= Time.deltaTime;
                if (shotTime < 0)
                {
                    if (shot >= shotCount)
                    {
                        waitTime += coolDown;
                        shot = 0;
                    }
                    else
                    {
                        shot++;
                        shotTime += shotDown;
                        GameObject inst = Instantiate(basicAttack, this.transform.position, transform.rotation);
                        inst.GetComponent<Rigidbody>().velocity = inst.transform.forward * velocity;
                        inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);
                    }
                }
            }
            if (chargeTime <= 0)
            {
                chargeTime += chargeDown;
                Vector3 angles = this.transform.rotation.eulerAngles;
                angles.y += (Random.value - 0.5f) * Mathf.Rad2Deg * 0.2f;

                GameObject inst = Instantiate(chargeAttack, this.transform.position, Quaternion.Euler(angles));
                inst.GetComponent<Rigidbody>().velocity = inst.transform.forward * chargeVelocity;
                inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = chargeDamage);

                GameObject inst2 = Instantiate(chargeAttack2, this.transform.position, Quaternion.Euler(angles));
                inst2.GetComponent<Rigidbody>().velocity = inst2.transform.forward * chargeVelocity;
                inst2.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = chargeDamage);
            }
        }
    }
}
