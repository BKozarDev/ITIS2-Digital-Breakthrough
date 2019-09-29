using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TaxationSliderFill : MonoBehaviour
{
    public GameObject buttonPrefab;

    public void FillButtons(List<Taxation> list)
    {
        if (list.Count == 1)
        {
            AddButtonEvent(list[0]);
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var temp in list)
        {
            GameObject go = Instantiate(buttonPrefab, transform);
            Button goButton = go.GetComponent<Button>();
            go.GetComponentInChildren<TextMeshProUGUI>().SetText(System.Enum.GetName(typeof(TaxationType), temp.taxationName));
            goButton.onClick.AddListener(() => AddButtonEvent(temp));
        }

        FixWidth(transform.childCount);
    }

    public void FixWidth(int buttonsLength)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, buttonsLength * GetComponent<GridLayoutGroup>().cellSize.y + (buttonsLength - 1) * (GetComponent<GridLayoutGroup>().spacing.y * 1.2f));
    }

    public void AddButtonEvent(Taxation tax)
    {
        InfoTransfer.Taxation = tax;
        SceneManager.LoadScene("Game Scene");
    }
}
