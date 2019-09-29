using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoClicker", menuName = "Skills/Auto Clicker")]
public class AutoClickerSkill : Skill
{
    public override void SkillActivation()
    {
        Debug.Log("Clicker! " + this.UpgradeLvl);
    }
}
