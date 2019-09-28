using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nalog : MonoBehaviour
{
    public NalogType type;
    public Controller controller;
    public float speed;

    private void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        controller.TapOnNalog(this);
    }
}
