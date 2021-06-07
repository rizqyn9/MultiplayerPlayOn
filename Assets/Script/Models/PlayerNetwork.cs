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

namespace Networking
{
    public class PlayerNetwork : NetworkBehaviour
    {
        [SyncVar]
        public string UserName;
        [SyncVar]
        public string Name;
        [SyncVar]
        public int Level;

        public MatchManager matchManager;

        private NetworkManagerExt _netManager;
        private NetworkManagerExt netManager
        {
            get
            {
                if (_netManager != null) { return _netManager; }
                return _netManager = NetworkManager.singleton as NetworkManagerExt;
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (!isLocalPlayer) return;
            cmdUpdateUser(GameManager.Instance.sharedPlayer);
        }

    //Sync Data User
        [Command]
        private void cmdUpdateUser(SharedPlayer _player)
        {
            netManager.DataPlayShared.Add(_player);
            UserName = _player.UserName;
            Name = _player.Name;
            Level = _player.Level;
        }
    }
}