using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashingText : MonoBehaviour
{
    public float minAlpha = 0.1f;
    public float maxAlpha = 0.9f;
    public float speedAlpha = 0f;

    private float timerAlphaT;
    private Color colorT;
    private bool timerToMax = false;
    private float currentAlphaT;

    // Start is called before the first frame update
    void Start()
    {
        timerAlphaT = speedAlpha / 100f;
        colorT = GetComponent<TextMeshProUGUI>().color;
        currentAlphaT = maxAlpha;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!timerToMax)
        {
            currentAlphaT -= timerAlphaT * Time.deltaTime;
            if (currentAlphaT < minAlpha)
                timerToMax = !timerToMax;
        }
        else
        {
            currentAlphaT += timerAlphaT * Time.deltaTime;
            if (currentAlphaT > maxAlpha)
                timerToMax = !timerToMax;
        }
        GetComponent<TextMeshProUGUI>().color = new Color(colorT.r, colorT.g, colorT.b, currentAlphaT);
    }
}