﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFire : MonoBehaviour
{
    public Projectile Note;
    public float coolDown;
    private float waitTime;
    // Use this for initialization
    void Start()
    {
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waitTime += coolDown;
            Projectile inst = Instantiate(Note, this.transform.position , this.transform.rotation);
            inst.player = gameObject.transform;
        }
    }
}
