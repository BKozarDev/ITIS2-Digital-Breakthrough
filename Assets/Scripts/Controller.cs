using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Controller : MonoBehaviour
{
    //temp
    public List<Skill> skills;
    public SkillSliderFill skillSlider;

    [SerializeField]
    private Character curCharacter;
    [SerializeField]
    private Taxation curTaxation;
    private int points;
    [SerializeField]
    private TextMeshProUGUI pointsText;
    [SerializeField]
    private int defaultPointsAdd = 100;
    [SerializeField]
    private WaterController waterController;

    private Dictionary<FieldOfActivityType, int> upgrades;

    public static Controller Instance;

    public Taxation GetCurTaxation()
    {
        return curTaxation;
    }

    void Awake()
    {
        if (Controller.Instance == null)
        {
            Controller.Instance = this;
        }

        points = PlayerPrefs.GetInt("Points", 0);
        points = 1000000;
        upgrades = new Dictionary<FieldOfActivityType, int>();
        foreach (FieldOfActivityType field in System.Enum.GetValues(typeof(FieldOfActivityType)))
        {
            int lvl = PlayerPrefs.GetInt(System.Enum.GetName(typeof(FieldOfActivityType), field), 0);
            upgrades.Add(field, lvl);
            skills.FirstOrDefault(x => x.fieldsSkill == field).UpgradeLvl = (short)lvl;
        }
        Debug.Log(upgrades.Count);

        if (InfoTransfer.Character != null && InfoTransfer.Taxation != null)
        {
            curCharacter = InfoTransfer.Character;
            Debug.Log(curCharacter);
            curTaxation = InfoTransfer.Taxation;
            Debug.Log(curTaxation);
        }

        pointsText.SetText(points.ToString());

        skillSlider.FillSkills(skills);
    }

    public void TapOnNalog(Nalog nalog)
    {
        if (curTaxation.nalogs.Exists(x => x == nalog.type))
        {
            //PointsAdd(10);
            // Создание чистой воды
            waterController.BubbleBursted(nalog.transform.position, (int)(nalog.transform.localScale.x * 10), true);
            Debug.Log("Click On Right Nalog");
        }
        else
        {
            //PointsAdd(-10);
            // Создание грязной воды
            waterController.BubbleBursted(nalog.transform.position, (int)(nalog.transform.localScale.x * 10), false);
            Debug.Log("Click On Wrong Nalog");
        }

    }

    private void PointsAdd(int points)
    {
        this.points += points;
        UpdateText();
    }

    public void WaterReset(float cleanliness)
    {
        // Добавляем очки, основываясь на чистоте воды
        PointsAdd((int)(defaultPointsAdd * cleanliness));

        //Rigged
        //PointsAdd(1000000);
        Save();
    }

    public void UpgradeField(FieldOfActivityType field, int price)
    {
        upgrades[field]++;
        points -= price;
        pointsText.SetText(points.ToString());
        skills.FirstOrDefault(x => x.fieldsSkill == field).UpgradeLvl = (short)upgrades[field];
        if (upgrades[field] - 1 == 0)
        {
            skillSlider.FillSkills(skills);
        }
        Save();
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

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
