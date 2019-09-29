using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSelect : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> canvases;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject menuButton;
    [SerializeField]
    private GameObject menuBackground;
    [SerializeField]
    private GameObject continueButton;
    private List<GameObject> nalogs;
    public void OpenSelecterCanvas(GameObject selectedCanvas)
    {
        menu.SetActive(false);
        //menuButton.SetActive(true);
        foreach (var canvas in canvases)
        {
            if (canvas == selectedCanvas)
            {
                canvas.SetActive(true);
                
                if (canvas.name == "Game Canvas")
                {
                    menu.SetActive(true);
                    continueButton.SetActive(true);
                    menuButton.SetActive(false);
                    menuBackground.SetActive(false);

                    foreach (var nalog in nalogs)
                    {
                        nalog.SetActive(true);
                        //TurnOnOffNalog(nalog, true);
                    }
                }
                else
                {
                    continueButton.SetActive(false);
                    menuBackground.SetActive(true);
                    nalogs = GameObject.FindGameObjectsWithTag("Nalog").ToList();
                    foreach (var nalog in nalogs)
                    {
                        nalog.SetActive(false);
                        //TurnOnOffNalog(nalog, false);
                    }
                }
            }
            else
            {
                canvas.SetActive(false);
            }
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //// Костыль, надо сделать движение налога через трансформ в апдейте и просто выключать его
    //private static void TurnOnOffNalog(GameObject nalog, bool on)
    //{
    //    nalog.GetComponent<SpriteRenderer>().enabled = on;
    //    nalog.GetComponent<Collider2D>().enabled = on;
    //    nalog.transform.GetChild(0).gameObject.SetActive(on);
    //    //nalog.GetComponentInChildren<TextMeshPro>().enabled = on;
    //}
}
