using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JenkyCameraMove : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;

    public float fadeTime = 2.5f;
    public float fadeDelay = 3.0f;
    public float fadeCurrent = 0;

    // Use this for initialization
    void Start()
    {
        transform.position = start;
    }

    // Update is called once per frame
    void Update()
    {
        fadeCurrent += Time.deltaTime;

        if (fadeCurrent >= fadeDelay)
        {
            float val = (fadeCurrent - fadeDelay) / fadeTime;
            transform.position = Vector3.Lerp(start, end, val);
        }
    }
}
