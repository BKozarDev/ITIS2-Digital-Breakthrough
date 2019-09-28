using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public void Pause(bool isPause)
    {
        if (!isPause)
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
