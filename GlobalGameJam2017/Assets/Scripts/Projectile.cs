using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region Variables
    public bool isLocalOrientation;

    public float deathTime = 2.0f;
    float LifeTime;
    public AnimationCurve amplitudeX;
    public AnimationCurve amplitudeZ;
    public AnimationCurve speedX;
    public AnimationCurve speedZ;
    public AnimationCurve frequencyX;
    public AnimationCurve frequencyZ;

    #endregion

    // Use this for initialization
    private void Start() {
        Destroy(gameObject, deathTime);
    }
	

    // Physics update
    private void FixedUpdate()
    {
        LifeTime += Time.deltaTime;
        float LifeTimePassed= LifeTime/deathTime;
        if (isLocalOrientation)
        {
            transform.position += transform.TransformVector(new Vector3(amplitudeX.Evaluate(LifeTimePassed) * Mathf.Cos(frequencyX.Evaluate(LifeTimePassed) * Time.time) * speedX.Evaluate(LifeTimePassed), 0.0f, amplitudeZ.Evaluate(LifeTimePassed) * Mathf.Sin(frequencyZ.Evaluate(LifeTimePassed) * Time.time) * speedZ.Evaluate(LifeTimePassed)));
        }
        else
        {
            transform.position += new Vector3(amplitudeX.Evaluate(LifeTimePassed) * Mathf.Cos(frequencyX.Evaluate(LifeTimePassed) * Time.time) * speedX.Evaluate(LifeTimePassed), 0.0f, amplitudeZ.Evaluate(LifeTimePassed) * Mathf.Sin(frequencyZ.Evaluate(LifeTimePassed) * Time.time) * speedZ.Evaluate(LifeTimePassed));
        }
    }


    // Rigidbody collision detection
    private void OnTriggerEnter(Collider cc)
    {
        Debug.Log("Collision");
        //Destroy(gameObject);
    }

} // end class Projectile