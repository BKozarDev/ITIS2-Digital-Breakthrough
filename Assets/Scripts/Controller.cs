﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Character curCharacter;
    [SerializeField]
    private Taxation curTaxation;
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    void Start()
    {
        if (InfoTransfer.Character != null && InfoTransfer.Taxation!=null)
        {
            curCharacter = InfoTransfer.Character;
            Debug.Log(curCharacter);
            curTaxation = InfoTransfer.Taxation;
            Debug.Log(curTaxation);
        }

        pointsText.SetText("0"); // Нужно сделать считывание с сохранения
    }

    public void TapOnNalog(Nalog nalog)
    {
        if (curTaxation.nalogs.Exists(x => x == nalog.type))
        {
            // Add points
            PointsAdd(10);
            Debug.Log("Click On Right Nalog");
        }
        else
        {
            // Minus points
            PointsAdd(-10);
            Debug.Log("Click On Wrong Nalog");
        }
    }

    private void PointsAdd(int points)
    {
        score += points;
        pointsText.SetText(score.ToString());
    }
}
