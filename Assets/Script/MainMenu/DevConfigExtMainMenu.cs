using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class DevConfigExtMainMenu : DevConfig
{
    [Header("CUSTOM DATA PLAYER")]
    [SerializeField] string Name = "Rizqy";
    [SerializeField] string ID = "index1";
    [SerializeField] string UserName = "PlayerKill";
    [SerializeField] int level = 2;

    private void Start()
    {
        if (isDevMode)
        { 
            Debug.Log("Running as Dev");
            GameManager localData = GameManager.instance;
            localData.UserName = UserName;
            localData.Name = Name;
            localData.ID = ID;
            localData.Level = level;
            Debug.Log(GameManager.Instance.UserName);

        }
    }
}
