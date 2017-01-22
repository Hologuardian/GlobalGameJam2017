using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMaster : MonoBehaviour
{
    int speakersLeft = 6;
    int playersLeft = 2;

    public void PlayerDied()
    {
        playersLeft--;
        if (playersLeft == 0)
            SceneManager.LoadScene("MarkSeaman");
    }

    public void SpeakerDied()
    {
        speakersLeft--;
        if (speakersLeft == 0)
            SceneManager.LoadScene("Credits");
    }
}
