using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public Sprite skillIcon;

    public float cooldown;
    public bool passive;
    public FieldOfActivityType fieldsSkill;

    private short upgradeLvl;

    public abstract void SkillActivation();

    public short UpgradeLvl
    {
        get
        {
            return upgradeLvl;
        }
        set
        {
            upgradeLvl = value;
        }
    }
}