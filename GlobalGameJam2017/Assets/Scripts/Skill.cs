using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public bool isLocalOriented;
    public GameObject bullet;

    public float radiusX = 1.5f;
    public float radiusZ = 1.5f;

    public Vector3 offset;

    public int divisions = 1;
    public float coneAngle = 2 * Mathf.PI;

    // Start
    private void Start()
    {
        Shoot(divisions);
    }

    // Shoot
    public void Shoot(int subdivisions = 1)
    {
        if (subdivisions < 1) {
            Debug.Log("Should not divide by 0 or below!");
            return;
        }

        for (int i = 0; i < subdivisions; i++)
        {
            float angleOffset = 0.0f;
            float theta = coneAngle / subdivisions;

            if (isLocalOriented) {
                angleOffset = Mathf.Atan2(transform.forward.z, transform.forward.x) - (coneAngle / 2);
            }

            float angle = i * theta + angleOffset;

            float x = Mathf.Cos(angle) * radiusX;
            float z = Mathf.Sin(angle) * radiusZ;

            Vector3 spawnPos = new Vector3(gameObject.transform.position.x + x, 1.0f, gameObject.transform.position.z + z);

            GameObject temp = Instantiate(bullet, spawnPos, Quaternion.LookRotation(new Vector3(x, 1.0f, z)));        
        }
    }

} // end class Skill
