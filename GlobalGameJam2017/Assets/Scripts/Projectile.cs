using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region Variables
    public bool isLocalOrientation;

    public float deathTime = 2.0f;
    public float amplitude = 1.0f;
    public float speed = 0.5f;
    public float frequency = 50.0f;
#endregion

    // Use this for initialization
    private void Start() {
        Destroy(gameObject, deathTime);
    }
	

    // Physics update
    private void FixedUpdate()
    {
        if (isLocalOrientation)
        {
            transform.position += transform.TransformVector(new Vector3(amplitude * Mathf.Cos(frequency * Time.time) * speed, 0.0f, amplitude * Mathf.Sin(frequency * Time.time) * speed));
        }
        else
        {
            transform.position += new Vector3(amplitude * Mathf.Cos(frequency * Time.time) * speed, 0.0f, amplitude * Mathf.Sin(frequency * Time.time) * speed);
        }
    }


    // Rigidbody collision detection
    private void OnTriggerEnter(Collider cc)
    {
        Debug.Log("Collision");
        //Destroy(gameObject);
    }

} // end class Projectile