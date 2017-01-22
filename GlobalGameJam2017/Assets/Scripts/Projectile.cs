using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool isLocalOrientation;
    private float time;

    public AnimationCurve X;
    public AnimationCurve Z;

    public float deathTime = 2.0f;
    public AnimationCurve frequency;
    public AnimationCurve xMagnitude;
    public AnimationCurve zMagnitude;
    public float Damage = 1.0f;

    public GameObject owner;

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
        //Debug.Log("Collision");
        //Destroy(gameObject);
        if (cc.gameObject.tag == "Player") {
            cc.GetComponent<TopDownController>().Health -= Damage;
            Destroy(this.gameObject);
        }
    }

} // end class Projectile