using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFire2 : MonoBehaviour
{
    public GameObject Note;
    public float coolDown;
    private float waitTime;
    public Vector3 spawnDelta;
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
            GameObject inst = Instantiate(Note, Vector3.zero, this.transform.rotation);
            inst.transform.parent = this.transform;
        }
    }
}
