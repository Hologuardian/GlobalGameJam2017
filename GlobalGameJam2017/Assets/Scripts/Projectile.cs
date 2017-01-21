using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
#region Variables
    Rigidbody rb;
    public bool isLocalOrientation;

    public float deathTime = 2.0f;
    public float amplitude = 1.0f;
    public float speed = 0.5f;
    public float frequency = 50.0f;
#endregion

    // Use this for initialization
    private void Start ()
    {
        rb = GetComponent<Rigidbody>();
        speed *= 0.5f;
        Destroy(gameObject, deathTime);
    }
	

    // Physics update
    private void FixedUpdate()
    {
        if (isLocalOrientation)
        {
            rb.MovePosition(rb.transform.position += rb.transform.TransformVector(new Vector3(speed, 0.0f, amplitude * Mathf.Sin(frequency * Time.time))));
        }
        else
        {
            rb.MovePosition(rb.transform.position += new Vector3(speed, 0.0f, amplitude * Mathf.Sin(frequency * Time.time)) );
        }
    }


    // Rigidbody collision detection
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        Destroy(gameObject);
    }

} // end class Projectile