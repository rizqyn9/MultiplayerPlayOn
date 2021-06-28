using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Dev")]
public class DevConfig : MonoBehaviour
{
    public bool isDevMode = true;

    [Header("Game Manager")]
    public bool isInstanceGameManagerPrefab = true;
    public GameObject gameManagerPrefab;
    public GameManager gameManager;
    GameObject _gameManager;


    [Header("CUSTOM DATA PLAYER")]
    public string Name = "Rizqy";
    public string ID = "index1";
    public string UserName = "PlayerKill";
    public int level = 2;

    [Header("CUSTOM ROOM DATA")]
    public bool isUseRoomData;
    public Room room;

    [Header("CONFIG INSTANCE")]
    public enumInstance instance;
    public enum enumInstance
    {
        isHost,
        isServer,
        isClient
    }

    public void Start()
    {
        if (isDevMode)
        {
            Debug.Log("Running Developer Mode");
        } else
        {
            Debug.Log("Running Production");
        }
    }

    public void instanceGameManger()
    {
        Debug.Log("Spawn Game Manager Dev COnfig");
        _gameManager = Instantiate(gameManagerPrefab);
        gameManager = _gameManager.GetComponent<GameManager>();
        gameManager.UserName = UserName;
        gameManager.Name = Name;
        gameManager.ID = ID;
        gameManager.Level = level;
    }

    public void setRoom()
    {
        room.Data = "Create dev room";
        room.IsPublic = true;
        room.Port = 5000;
        room.RoomID = "PELER";
        gameManager.DataRoom = room;
    }
}
