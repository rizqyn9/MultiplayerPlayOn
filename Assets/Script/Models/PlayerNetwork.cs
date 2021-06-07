using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[System.Serializable]
public struct SharedPlayer
{
    public string UserName;
    public string Name;
    public int Level;
}

public class PlayerNetwork : NetworkBehaviour
{
    [SyncVar]
    public string UserName;
    [SyncVar]
    public string Name;
    [SyncVar]
    public int Level;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (!isLocalPlayer) return;
        cmdUpdateUser(GameManager.Instance.sharedPlayer);
    }

    [Command]
    private void cmdUpdateUser(SharedPlayer _player)
    {
        UserName = _player.UserName;
        Name = _player.Name;
        Level = _player.Level;
    }
}