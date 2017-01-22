using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Speaker : MonoBehaviour
{
    public GameObject basicAttack;
    public GameObject chargeAttack;
    public GameObject chargeAttack2;
    public float velocity;
    public float chargeVelocity;
    public float Damage = 1.0f;
    public float coolDown;
    public int shotCount = 6;
    public float chargeDown;
    public float shotDown;
    private float waitTime;
    private float chargeTime;
    private float shotTime;
    private int shot = 0;

    // Use this for initialization
    void Start()
    {
        waitTime = coolDown;
        chargeTime = chargeDown;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        chargeTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            shotTime -= Time.deltaTime;
            if(shotTime < 0)
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
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);

            GameObject inst2 = Instantiate(chargeAttack2, this.transform.position, Quaternion.Euler(angles));
            inst2.GetComponent<Rigidbody>().velocity = inst2.transform.forward * chargeVelocity;
            inst2.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);
        }
    }
}
