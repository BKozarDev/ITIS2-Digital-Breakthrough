using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSliderFill : MonoBehaviour
{
    public GameObject buttonPrefab;

    public void FillSkills(List<Skill> list)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var temp in list)
        {
            if (!temp.passive && temp.UpgradeLvl > 0)
            {
                GameObject go = Instantiate(buttonPrefab, transform);
                Button goButton = go.GetComponent<Button>();
                goButton.onClick.AddListener(() => temp.SkillActivation());
                go.GetComponent<Image>().sprite = temp.skillIcon;
            }
        }

        FixWidth(transform.childCount);
    }

    public void FixWidth(int buttonsLength)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, buttonsLength * GetComponent<GridLayoutGroup>().cellSize.y + (buttonsLength - 1) * (GetComponent<GridLayoutGroup>().spacing.y * 1.2f));
    }
}
