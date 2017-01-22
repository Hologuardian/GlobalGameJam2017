using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JenkyTextMove : MonoBehaviour
{
    public Text text;

    public float heightStart = -700;
    public float heightEnd = 700;

    public float transitionTime = 30.0f;
    public float fadeDelay = 35.0f;
    public float fadeCurrent = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fadeCurrent += Time.deltaTime;

        Vector3 pos = text.rectTransform.localPosition;

        float val = fadeCurrent / transitionTime;

        pos.y = Mathf.Lerp(heightStart, heightEnd, val);

        text.rectTransform.localPosition = pos;

        if (fadeCurrent >= fadeDelay)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
