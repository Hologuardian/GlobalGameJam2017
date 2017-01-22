using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region Variables
    public bool isLocalOrientation;

    public float deathTime = 2.0f;
    float LifeTime;
    public AnimationCurve X;
    public AnimationCurve Z;

    public float Amp = 20.0f;
    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    public float speedUpTime = 0.5f;
    private Vector3 axisX, axisZ;


    #endregion

    // Use this for initialization
    private void Start() {
        Destroy(gameObject, deathTime);
        axisX = transform.right;
        axisZ = transform.forward;
    }
	

    // Physics update
    private void FixedUpdate()
    {
        LifeTime += Time.deltaTime* speedUpTime;
        float LifeTimePassed= LifeTime/deathTime;
        if (isLocalOrientation)
        {
            transform.position += transform.TransformVector(new Vector3(
             X.Evaluate(LifeTime), 0.0f, Z.Evaluate(LifeTime)));
            //transform.position += new Vector3(0.1f,0, amplitudeZ.Evaluate(LifeTimePassed) * Mathf.Sin(frequencyZ.Evaluate(LifeTimePassed) * Time.time) * speedZ.Evaluate(LifeTimePassed));
            //transform.position += axisX * Mathf.Cos(LifeTime * frequencyX.Evaluate(LifeTimePassed)) * speedX.Evaluate(LifeTimePassed);
            //transform.position += amplitudeX.Evaluate(LifeTimePassed) * Mathf.Cos(LifeTime * frequencyX.Evaluate(LifeTimePassed)) * speedX.Evaluate(LifeTimePassed);
            //transform.position += axisZ * Mathf.Sin(LifeTime * frequencyZ.Evaluate(LifeTimePassed)) * speedZ.Evaluate(LifeTimePassed);
        }
        else
        {
            /*
            transform.position += new Vector3(
                amplitudeX.Evaluate(LifeTimePassed) * Mathf.Cos(frequencyX.Evaluate(LifeTimePassed) * Time.time) * speedX.Evaluate(LifeTimePassed), 0.0f, 
                amplitudeZ.Evaluate(LifeTimePassed) * Mathf.Sin(frequencyZ.Evaluate(LifeTimePassed) * Time.time) * speedZ.Evaluate(LifeTimePassed));*/
        }
    }


    // Rigidbody collision detection
    private void OnTriggerEnter(Collider cc)
    {
        Debug.Log("Collision");
        //Destroy(gameObject);
    }

} // end class Projectile