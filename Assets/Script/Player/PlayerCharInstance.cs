using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharInstance : MonoBehaviour
{
    public GameObject modelInstance;
    public List<CharacterBase> charList;

    public GameObject SpawnChar(int code)
    {
        GameObject instance = Instantiate(charList[code].modelCharacter, modelInstance.transform);
        return instance;
    }

}
