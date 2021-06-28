using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeplayonMainMenu;
using UnityEngine.UI;
using Matchmaker;
using Mirror;

[AddComponentMenu("")]
public class DevConfigExtMainMenu : DevConfig
{
    public GameObject devStartBtn;
    public UI_MatchMaking uI_MatchMaking;
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
            if (isUseRoomData)
            {
                setRoom();
            }

            devStartBtn.SetActive(true);
        }
    }

    public void StartDev()
    {
        if (instance == enumInstance.isHost) NetworkManager.singleton.StartHost();
        if (instance == enumInstance.isServer) NetworkManager.singleton.StartServer();
        if (instance == enumInstance.isClient) NetworkManager.singleton.StartClient();
    }
}
