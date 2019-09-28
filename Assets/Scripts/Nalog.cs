using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nalog : MonoBehaviour
{
    public NalogType type;
    public Controller controller;

    private void OnMouseDown()
    {
        controller.TapOnNalog(this);
    }
}
