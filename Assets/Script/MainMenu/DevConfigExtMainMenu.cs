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
    [SerializeField] int Level = 2;

    private void Start()
    {
        if (isDevMode)
        { 
            Debug.Log("Running as Dev");

            // Adding data to Game manager {Persistant data}
            GameManager localData = GameManager.instance;
            localData.UserName = UserName;
            localData.Name = Name;
            localData.ID = ID;
            localData.Level = Level;

                //Adding Shared Player {Shared Data for multiplayer}
            SharedPlayer sharedPlayer;
            sharedPlayer.Name = Name;
            sharedPlayer.Level = Level;
            sharedPlayer.UserName = UserName;

            localData.sharedPlayer = sharedPlayer;

            //Debug.Log(GameManager.Instance.UserName);

        }
    }
}
