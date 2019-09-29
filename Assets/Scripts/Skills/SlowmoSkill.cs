using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlowMotion", menuName = "Skills/Slowmo")]
public class SlowmoSkill : Skill
{
    public override void SkillActivation()
    {
        Debug.Log("SLOWMO " + this.UpgradeLvl);
    }
}