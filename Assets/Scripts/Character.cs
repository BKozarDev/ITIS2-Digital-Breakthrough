using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character", order = 51)]
public class Character : ScriptableObject
{
    public CharacterType characterType;
    public List<Taxation> taxations;
}
