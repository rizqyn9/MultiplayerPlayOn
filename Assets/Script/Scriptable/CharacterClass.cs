using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharClassType : byte
{
    None,
    Char1,
    Char2,
    Char3
}

[CreateAssetMenu(menuName = "GameData/CharacterClass", order = 2)]
public class CharacterClass : ScriptableObject
{
    public CharClassType charClassType;
    public string ModelName;
    public Animator animatorController;
    public GameObject playerObject;
}

