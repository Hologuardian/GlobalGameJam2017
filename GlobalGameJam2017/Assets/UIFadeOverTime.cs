using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeOverTime : MonoBehaviour
{
    public Image image;

    public float fadeTime = 2.5f;
    public float fadeDelay = 3.0f;
    public float fadeCurrent = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeCurrent += Time.deltaTime;

        if (fadeCurrent >= fadeDelay)
        {
            Color color = image.color;
            color.a = 1 - ((fadeCurrent - fadeDelay) / fadeTime);
            image.color = color;
        }
    }
}
