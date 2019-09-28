using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FillSlider : MonoBehaviour
{
    public GameObject buttonPrefab;

    public void FillButtons(List<Taxation> list)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var temp in list)
        {
            GameObject go = Instantiate(buttonPrefab, transform);
            Button goButton = go.GetComponent<Button>();
            goButton.onClick.AddListener(() => AddButtonEvent(temp));
        }

        FixWidth(transform.childCount);
    }

    public void FixWidth(int buttonsLength)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(buttonsLength * GetComponent<GridLayoutGroup>().cellSize.x + (buttonsLength - 1) * (GetComponent<GridLayoutGroup>().spacing.x * 1.2f),
            GetComponent<RectTransform>().sizeDelta.y);
    }

    public void AddButtonEvent(Taxation tax)
    {
        InfoTransfer.Taxation = tax;
        SceneManager.LoadScene("Game Scene");
    }
}
