using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region Variables
    public bool isLocalOrientation;
    private float time;

    public AnimationCurve X;
    public AnimationCurve Z;

    public float deathTime = 2.0f;
    public AnimationCurve frequency;
    public AnimationCurve xMagnitude;
    public AnimationCurve zMagnitude;


    #endregion

    // Use this for initialization
    private void Start()
    {
        Destroy(gameObject, deathTime);
        Destroy(transform.parent.gameObject, deathTime);
    }
	

    // Physics update
    private void Update()
    {
        time += Time.deltaTime * frequency.Evaluate(Time.time);
        if(isLocalOrientation)
        {
            transform.position = transform.parent.position 
                + transform.parent.right * X.Evaluate(time) * xMagnitude.Evaluate(time) 
                + transform.parent.forward * Z.Evaluate(time) * zMagnitude.Evaluate(time);
        }
        else
        {
            transform.position = transform.parent.position + new Vector3(X.Evaluate(time) * xMagnitude.Evaluate(time), 0, Z.Evaluate(time) * zMagnitude.Evaluate(time));
        }
    }


    // Rigidbody collision detection
    private void OnTriggerEnter(Collider cc)
    {
        Debug.Log("Collision");
        //Destroy(gameObject);
    }

} // end class Projectile