using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBarController : MonoBehaviour
{
    public Slider[] sliders = new Slider[5];

    public void UpdateBars(int upgraded)
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            if (i < upgraded)
                sliders[i].value = sliders[i].maxValue;
            else
                sliders[i].value = sliders[i].minValue;
        }
    }
}
