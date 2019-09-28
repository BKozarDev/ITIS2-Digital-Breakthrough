using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Character curCharacter;
    [SerializeField]
    private Taxation curTaxation;
    private int points;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private Dictionary<FieldOfActivityType, int> upgrades = new Dictionary<FieldOfActivityType, int>();

    void Awake()
    {
        points = PlayerPrefs.GetInt("Points", 0);
        foreach (FieldOfActivityType field in System.Enum.GetValues(typeof(FieldOfActivityType)))
        {
            upgrades.Add(field, PlayerPrefs.GetInt(System.Enum.GetName(typeof(FieldOfActivityType), field), 0));
        }

        if (InfoTransfer.Character != null && InfoTransfer.Taxation != null)
        {
            curCharacter = InfoTransfer.Character;
            Debug.Log(curCharacter);
            curTaxation = InfoTransfer.Taxation;
            Debug.Log(curTaxation);
        }

        pointsText.SetText(points.ToString());
    }

    public void TapOnNalog(Nalog nalog)
    {
        if (curTaxation.nalogs.Exists(x => x == nalog.type))
        {
            // Add points
            PointsAdd(10);
            Debug.Log("Click On Right Nalog");
        }
        else
        {
            // Minus points
            PointsAdd(-10);
            Debug.Log("Click On Wrong Nalog");
        }
    }

    private void PointsAdd(int points)
    {
        this.points += points;
        UpdateText();
    }

    public void UpgradeField(FieldOfActivityType field, int price)
    {
        upgrades[field]++;
        points -= price;
        pointsText.SetText(points.ToString());
    }

    public int GetField(FieldOfActivityType field)
    {
        return upgrades[field];
    }

    public int Points
    {
        get { return points; }
    }

    public int GetPriceForNextLvl(FieldOfActivityType field)
    {
        int curLvl = GetField(field);
        return (curLvl + 1) * 100;
    }

    public void UpdateText()
    {
        pointsText.SetText(points.ToString());
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Points", points);
        foreach (FieldOfActivityType field in System.Enum.GetValues(typeof(FieldOfActivityType)))
        {
            PlayerPrefs.SetInt(System.Enum.GetName(typeof(FieldOfActivityType), field), upgrades[field]);
        }
    }
}
