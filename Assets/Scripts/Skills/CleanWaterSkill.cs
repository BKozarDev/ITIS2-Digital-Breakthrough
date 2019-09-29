using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleanWater", menuName = "Skills/Clean Water")]
public class CleanWaterSkill : Skill
{
    public override void SkillActivation()
    {
        Debug.Log("Purity, cleanity! " + this.UpgradeLvl);
    }
}