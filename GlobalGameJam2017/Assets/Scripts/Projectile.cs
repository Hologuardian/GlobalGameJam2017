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
        Physics.IgnoreCollision(GetComponent<Collider>(), owner.GetComponent<Collider>(), true);
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
        if (cc == null || cc.gameObject == null)
            return;
        //Debug.Log("Collision");
        //Destroy(gameObject);
        if (cc.gameObject.tag == "Player" && cc.gameObject != owner)
        {
            TopDownController controller = cc.gameObject.GetComponent<TopDownController>();
            Speaker speaker = cc.gameObject.GetComponent<Speaker>();
            if (controller)
                controller.Health -= Damage;
            if (speaker)
                speaker.health -= Damage;
            Destroy(this.transform.parent.gameObject);
        }
    }

} // end class Projectile