using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool isPause = false;
    public void Pause()
    {
        if (isPause)
        {
            Time.timeScale = 1f;
            isPause = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPause = true;
        }
    }
}
