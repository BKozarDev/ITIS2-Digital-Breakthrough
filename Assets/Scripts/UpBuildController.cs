using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpBuildController : MonoBehaviour
{
    public Controller controller;
    public TextMeshProUGUI buildingName;
    public UpgradeBarController upgradeBarController;
    public FieldOfActivityType fieldOfActivityType;

    void Start()
    {
        buildingName.SetText(System.Enum.GetName(typeof(FieldOfActivityType), fieldOfActivityType));
        upgradeBarController.UpdateBars(controller.GetField(fieldOfActivityType));
    }

    public void UpdateLvl()
    {
        if (controller.GetField(fieldOfActivityType) < 5)
        {
            int price = controller.GetPriceForNextLvl(fieldOfActivityType);
            if (price < controller.Points)
            {
                controller.UpgradeField(fieldOfActivityType, price);
                upgradeBarController.UpdateBars(controller.GetField(fieldOfActivityType));
            }
            else
            {
                Debug.Log("No Points");
            }
        }
        else
        {
            Debug.Log("Max Lvl");
        }
    }
}
