using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{
    public GameObject slider;

    public GameObject leftChar;
    public GameObject rightChar;
    public GameObject upChar;

    public int speed = 250;

    public float leftCharOut = -300f;
    public float leftCharIn = 300f;

    public float rightCharOut = 300f;
    public float rightCharIn = -300f;

    public float upCharOut = 300f;
    public float upCharIn = -300f;

    private RectTransform left;
    private RectTransform right;
    private RectTransform up;

    private float timer = 0f;
    private bool anim = false;
    private bool animIn;

    private GameObject sliderContainer;

    // Start is called before the first frame update
    void Start()
    {
        left = leftChar.GetComponent<RectTransform>();
        right = rightChar.GetComponent<RectTransform>();
        up = upChar.GetComponent<RectTransform>();

        sliderContainer = slider.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (anim)
        {
            timer += speed / 100f * Time.deltaTime;
            // Debug.Log(timer);
            if (animIn)
            {
                left.anchoredPosition = new Vector2(Mathf.Lerp(leftCharOut, leftCharIn, timer), left.anchoredPosition.y);
                right.anchoredPosition = new Vector2(Mathf.Lerp(rightCharOut, rightCharIn, timer), right.anchoredPosition.y);
                up.anchoredPosition = new Vector2(up.anchoredPosition.x, Mathf.Lerp(upCharOut, upCharIn, timer));
            }
            else
            {
                left.anchoredPosition = new Vector2(Mathf.Lerp(leftCharIn, leftCharOut, timer), left.anchoredPosition.y);
                right.anchoredPosition = new Vector2(Mathf.Lerp(rightCharIn, rightCharOut, timer), right.anchoredPosition.y);
                up.anchoredPosition = new Vector2(up.anchoredPosition.x, Mathf.Lerp(upCharIn, upCharOut, timer));
            }
            if (timer > 1)
            {
                anim = false;
                timer = 0;
                if (!animIn)
                    slider.SetActive(true);
            }
        }
    }

    public void MoveIn()
    {
        anim = true;
        animIn = true;
    }

    public void MoveOut()
    {
        anim = true;
        animIn = false;
    }

    public void ChooseChar(Character character)
    {
        InfoTransfer.Character = character;
        sliderContainer.GetComponent<TaxationSliderFill>().FillButtons(character.taxations);
    }
}