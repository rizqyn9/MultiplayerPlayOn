using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharTestEnum : byte
{
    None,
    Char1,
    Char2,
    Char3
}

[CreateAssetMenu(menuName = "GameData/CharacterTesting", order = 2)]
public class CharacterTesting : ScriptableObject
{
    public string NameChar;
    public GameObject model;
    public Animation animation;
    public CharTestEnum CharTestEnum;
}
