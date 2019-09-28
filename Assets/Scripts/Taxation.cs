using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Taxation", menuName = "Taxation", order = 52)]
public class Taxation : ScriptableObject
{
    public TaxationType taxationName;
    public List<NalogType> nalogs;
}