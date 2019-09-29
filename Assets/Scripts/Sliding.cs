using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    public RectTransform expander;

    public GameObject panel;

    public float spellsOut = -60;
    public float spellsIn = -180;

    public int speed = 250;

    private float timer = 0f;
    private bool anim = false;
    private bool animIn;

    private RectTransform panelMove;

    private bool spellsOutBool = false;

    // Start is called before the first frame update
    void Start()
    {
        panelMove = panel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim)
        {
            timer += speed / 100f * Time.deltaTime;
            Debug.Log(timer);
            if (animIn)
            {
                panelMove.anchoredPosition = new Vector2(Mathf.Lerp(spellsOut, spellsIn, timer), panelMove.anchoredPosition.y);
            }
            else
            {
                panelMove.anchoredPosition = new Vector2(Mathf.Lerp(spellsIn, spellsOut, timer), panelMove.anchoredPosition.y);
            }
            if (timer > 1)
            {
                anim = false;
                timer = 0;
            }
        }
    }

    public void Move()
    {
        if (!spellsOutBool)
        {
            expander.rotation = Quaternion.Euler(Vector3.zero);
            anim = true;
            animIn = true;
            spellsOutBool = true;
        }
        else
        {
            expander.rotation = Quaternion.Euler(0, 0, 180);
            anim = true;
            animIn = false;
            spellsOutBool = false;
        }
    }
}