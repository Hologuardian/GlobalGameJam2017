using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestFire : MonoBehaviour
{
    public GameObject Note;
    public float coolDown;
    public float velocity;
    private float waitTime;
    public float Damage = 1.0f;
    // Use this for initialization
    void Start()
    {
        waitTime = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waitTime += coolDown;
            GameObject inst = Instantiate(Note, this.transform.position , this.transform.rotation);
            inst.GetComponent<Rigidbody>().velocity = transform.forward * velocity;
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);;
        }
    }
}
