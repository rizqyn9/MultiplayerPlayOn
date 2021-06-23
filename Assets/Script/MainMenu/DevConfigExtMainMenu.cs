using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeplayonMainMenu;

[AddComponentMenu("")]
public class DevConfigExtMainMenu : DevConfig
{
    [Header("DevConfigExtMainMenu")]
    public UI_MainMenu uI_MainMenu;
    public void Start()
    {
        if (isDevMode)
        {
            Debug.Log("dev");
            if (isInstanceGameManagerPrefab)
            {
                instanceGameManger();
                uI_MainMenu.setUpProfile();
            }
        }
    }
}
