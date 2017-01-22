using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JenkyPressor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;
            if (Physics.Raycast(ray, out rayhit))
            {
                if (rayhit.collider.gameObject.name == "title_play")
                {
                    // This means we need to go play
                    SceneManager.LoadScene("MarkSeaman");
                }
                else if (rayhit.collider.gameObject.name == "title_credits")
                {
                    // This means we need to go to the credits screen
                    SceneManager.LoadScene("Credits");
                }
                else if (rayhit.collider.gameObject.name == "title_exit")
                {
                    // This means we need to leave
                    Application.Quit();
                }
            }
        }
    }
}
