using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region // Variables
    public Rigidbody2D rb2D;

    public float amplitude;
    public float cycle;

    public float Xspeed;
    public float Yspeed;
    public float deathTime;
    public float frequency;
#endregion

    // Use this for initialization
    void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, deathTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SineWaveTranformation()
    {

    }

} // end class Projectile