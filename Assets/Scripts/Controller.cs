using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Controller : MonoBehaviour
{
    Character curCharacter;
    Taxation curTaxation;
    public void TapOnNalog(Nalog nalog)
    {
        if (curTaxation.nalogs.Exists(x => x == nalog.type))
        {
            // Add points
        }
        else
        {
            // Minus points
        }
    }
}
