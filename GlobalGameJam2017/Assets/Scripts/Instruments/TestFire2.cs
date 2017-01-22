using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestFire2 : MonoBehaviour
{
    public GameObject Note;
    public float coolDown;
    private float waitTime;
    public Vector3 spawnDelta;
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
            GameObject inst = Instantiate(Note, transform.position + spawnDelta, this.transform.rotation);
            inst.transform.parent = this.transform;
            inst.GetComponentsInChildren<Projectile>().ToList().ForEach(x => x.Damage = Damage);
        }
    }
}
