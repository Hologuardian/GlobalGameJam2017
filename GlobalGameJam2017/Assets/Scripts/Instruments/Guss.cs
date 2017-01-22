using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Guss : MonoBehaviour
{
    public GameObject deadlyAttack;
    public GameObject deadlyAttack2;
    public Animator controller;
    public float deadlyDamage = 5.0f;
    public float deadlyDown;
    public float deadlyDuration;
    public float deadlyShotDown;
    
    private float deadlyTime;
    private float deadlyLength = 0;
    private float deadlyShotTime = 0;
    // Use this for initialization
    void Start ()
    {
        deadlyTime = deadlyDown;
    }
	
	// Update is called once per frame
	void Update ()
    {
        deadlyTime -= Time.deltaTime;
        if (deadlyTime <= 0)
        {
            controller.SetBool("Heavyattack", true);
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
    }
}
