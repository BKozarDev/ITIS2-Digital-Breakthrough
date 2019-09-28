using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{
    public GameObject slider;

    public List<GameObject> leftChar;
    public List<GameObject> rightChar;

    public int speed = 250;

    public float leftCharOut = -300f;
    public float leftCharIn = 300f;

    public float rightCharOut = 300f;
    public float rightCharIn = -300f;

    private List<RectTransform> left = new List<RectTransform>();
    private List<RectTransform> right = new List<RectTransform>();

    private float timer = 0f;
    private bool anim = false;
    private bool animIn;

    private GameObject sliderContainer;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject temp in leftChar)
            left.Add(temp.GetComponent<RectTransform>());
        foreach (GameObject temp in rightChar)
            right.Add(temp.GetComponent<RectTransform>());

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
                foreach (var temp in left)
                    temp.anchoredPosition = new Vector2(Mathf.Lerp(leftCharOut, leftCharIn, timer), temp.anchoredPosition.y);
                foreach (var temp in right)
                    temp.anchoredPosition = new Vector2(Mathf.Lerp(rightCharOut, rightCharIn, timer), temp.anchoredPosition.y);
            }
            else
            {
                foreach (var temp in left)
                    temp.anchoredPosition = new Vector2(Mathf.Lerp(leftCharIn, leftCharOut, timer), temp.anchoredPosition.y);
                foreach (var temp in right)
                    temp.anchoredPosition = new Vector2(Mathf.Lerp(rightCharIn, rightCharOut, timer), temp.anchoredPosition.y);
            }
            if (timer > 1)
            {
                anim = false;
                timer = 0;
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
        sliderContainer.GetComponent<FillSlider>().FillButtons(character.taxations);
        slider.SetActive(true);
    }
}