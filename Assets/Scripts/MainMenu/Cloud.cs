using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public CloudsController cloudsController;

    private int speed;
    private bool leftToRight;
    private RectTransform selfRect;

    private int width;
    private int height;

    // Start is called before the first frame update
    void Start()
    {
        selfRect = GetComponent<RectTransform>();
        SetNewMovement();

        width = 1080;
        height = 1920;
    }

    // Update is called once per frame
    void Update()
    {
        selfRect.localPosition = new Vector2(selfRect.localPosition.x + speed * Time.deltaTime * (leftToRight == true ? 1 : -1), selfRect.localPosition.y);
        if (leftToRight == true && selfRect.localPosition.x > width / 2 + selfRect.sizeDelta.x / 2)
        {
            SetNewMovement();
        }
        else if (leftToRight == false && selfRect.localPosition.x < -1 * width / 2 - selfRect.sizeDelta.x / 2)
        {
            SetNewMovement();
        }
    }

    private void SetNewMovement()
    {
        speed = Random.Range(50, 100);
        if (Random.Range(0f, 1f) < 0.5f)
        {
            leftToRight = true;
        }
        else
        {
            leftToRight = false;
        }
        selfRect.localPosition = new Vector2(540 * (leftToRight == true ? -1 : 1) + (leftToRight == true ? -1 * selfRect.sizeDelta.x / 2 : selfRect.sizeDelta.x / 2),
            Random.Range(-1920 / 2 + selfRect.sizeDelta.y / 2, 1920 / 2 - selfRect.sizeDelta.y / 2));
    }
}
