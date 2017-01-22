using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region Variables
    public bool isLocalOrientation;
    public Transform player;
    public Vector3 center;
    private float time;

    public AnimationCurve X;
    public AnimationCurve Z;

    public float deathTime = 2.0f;
    public float frequency = 1.0f;
    public float magnitude = 1.0f;


    #endregion

    // Use this for initialization
    private void Start()
    {
        Destroy(gameObject, deathTime);
        if (!isLocalOrientation)
        {
            center = player.position;
        }
    }
	

    // Physics update
    private void Update()
    {
        time += Time.deltaTime * frequency;
        if(isLocalOrientation)
        {
            transform.position = player.position + new Vector3(X.Evaluate(time), 0, Z.Evaluate(time)) * magnitude;
        }
        else
        {
            transform.position = center + new Vector3(X.Evaluate(time), 0, Z.Evaluate(time)) * magnitude;
        }
    }


    // Rigidbody collision detection
    private void OnTriggerEnter(Collider cc)
    {
        Debug.Log("Collision");
        //Destroy(gameObject);
    }

} // end class Projectile