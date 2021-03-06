using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSource : MonoBehaviour
{
    public static CharacterSource Instance { get; private set; }

    [SerializeField] List<CharacterBase> characterBases = new List<CharacterBase>();

    private void Awake()
    {
        if (Instance != null)
        {
            throw new System.Exception("Multiple GameDataSources defined!");
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public CharacterBase SelectChar(CharTypeEnum charTypeEnum)
    {
        Debug.Log("SelectChar");
        CharacterBase getChar = characterBases.Find(prefab => prefab.CharType == charTypeEnum);
        Debug.Log($"Got Character {getChar.nameCharacter}");
        Debug.Log("success Instantiate");
        return getChar;
    }
}
