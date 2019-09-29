using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Extinguish", menuName = "Skills/Extinguish")]
public class ExtinguishSkill : Skill
{
    public override void SkillActivation()
    {
        Debug.Log("DIE INSECT! " + this.UpgradeLvl);
    }
}