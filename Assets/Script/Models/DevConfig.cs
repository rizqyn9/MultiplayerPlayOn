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
        gameManager.ID = ID;
        gameManager.Level = level;
    }
}
