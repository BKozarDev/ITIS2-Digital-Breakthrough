using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Extinguish", menuName = "Skills/Extinguish")]
public class ExtinguishSkill : Skill
{
    public override void SkillActivation()
    {
        Taxation curTaxation = Controller.Instance.GetCurTaxation();
        List<GameObject> nalogsOnScene = GameObject.FindGameObjectsWithTag("Nalog").ToList();
        foreach (var nalog in nalogsOnScene)
        {
            if(!curTaxation.nalogs.Exists(x => x == nalog.GetComponent<Nalog>().type))
            {
                Destroy(nalog);
                nalog.GetComponent<Animator>().enabled = true;
                nalog.GetComponent<Animator>().SetBool("isDead", true);
            }
        }
        Debug.Log("DIE INSECT! " + this.UpgradeLvl);
    }
}