using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelect : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> canvases;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject menuButton;
    [SerializeField]
    private GameObject continueButton;
    public void OpenSelecterCanvas(GameObject selectedCanvas)
    {
        menu.SetActive(false);
        menuButton.SetActive(true);
        foreach (var canvas in canvases)
        {
            if(canvas == selectedCanvas)
            {
                canvas.SetActive(true);
                if (canvas.name == "Game Canvas")
                {
                    menu.SetActive(true);
                    menuButton.SetActive(false);
                }
                else
                {
                    continueButton.SetActive(false);
                }
            }
            else
            {
                canvas.SetActive(false);
            }
        }
    }
}
