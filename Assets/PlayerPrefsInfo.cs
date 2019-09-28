using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInfo : MonoBehaviour
{
    private int points;
    private Dictionary<FieldOfActivityType, int> upgrades = new Dictionary<FieldOfActivityType, int>();

    void Awake()
    {
        points = PlayerPrefs.GetInt("Points", 0);
        foreach (FieldOfActivityType field in System.Enum.GetValues(typeof(FieldOfActivityType)))
        {
            upgrades.Add(field, PlayerPrefs.GetInt(System.Enum.GetName(typeof(FieldOfActivityType), field), 0));
        }
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
