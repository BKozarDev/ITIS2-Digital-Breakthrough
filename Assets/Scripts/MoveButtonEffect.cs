using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonEffect : MonoBehaviour
{
    public GameObject rightChar;
    public GameObject leftChar;

    public int speed = 250;

    public float leftCharOut = -300f;
    public float leftCharIn = 300f;

    public float rightCharOut = 300f;
    public float rightCharIn = -300f;

    private RectTransform left;
    private RectTransform right;

    private float timer = 0f;
    private bool anim = false;
    private bool animIn;

    // Start is called before the first frame update
    void Start()
    {
        left = leftChar.GetComponent<RectTransform>();
        right = rightChar.GetComponent<RectTransform>();
    }

    void Update()
    {
        // Debug.Log(left.anchoredPosition.x);
        if (anim)
        {
            timer += speed / 100f * Time.deltaTime;
            Debug.Log(timer);
            if (animIn)
            {
                left.anchoredPosition = new Vector2(Mathf.Lerp(leftCharOut, leftCharIn, timer), left.anchoredPosition.y);
                right.anchoredPosition = new Vector2(Mathf.Lerp(rightCharOut, rightCharIn, timer), right.anchoredPosition.y);
            }
            else
            {
                left.anchoredPosition = new Vector2(Mathf.Lerp(leftCharIn, leftCharOut, timer), left.anchoredPosition.y);
                right.anchoredPosition = new Vector2(Mathf.Lerp(rightCharIn, rightCharOut, timer), right.anchoredPosition.y);
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
}
