using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/CharacterBase", order = 1)]
public class CharacterBase : ScriptableObject
{
    [Tooltip("Set name character")]
    public string nameCharacter;

    [Tooltip("Prefab for this Character")]
    public GameObject modelCharacter;

    [Tooltip("unique code as identity for player character")]
    public CharTypeEnum CharType;

}
