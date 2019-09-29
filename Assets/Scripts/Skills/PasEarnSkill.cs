using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Passive Earning", menuName = "Skills/Passive Earning")]
public class PasEarnSkill : Skill
{
    public override void SkillActivation()
    {
        Debug.Log("Eaziest money of my life " + this.UpgradeLvl);
    }
}
