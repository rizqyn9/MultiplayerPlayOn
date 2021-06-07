using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public struct PlayerData
{
    public string UserName;
    public string Name;
    public int Level;
}

namespace Networking
{
    public class MatchManager : NetworkBehaviour
    {
        [SerializeField]
        private string _test = "test";
        public string test
        {
            get => _test;
            set
            {
                _test = value;
            }
        }

        private NetworkManagerExt _netManager;
        private NetworkManagerExt netManager
        {
            get
            {
                if (_netManager != null) { return _netManager; }
                return _netManager = NetworkManager.singleton as NetworkManagerExt;
            }
        }

        public int countListData = 0;
        public SyncList<SharedPlayer> listDataPlayer = new SyncList<SharedPlayer>();

        [SerializeField]
        public SyncList<string> playerUsername = new SyncList<string>();

        public int countListDetailPlayer;
        public SyncDictionary<uint, SharedPlayer> ListDetailPlayer = new SyncDictionary<uint, SharedPlayer>();



        private void Update()
        {
            if (!isLocalPlayer) return;
            countListData = listDataPlayer.Count;
            countListDetailPlayer = ListDetailPlayer.Count;
        }


        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public override void OnStartAuthority()
        {
            base.OnStartAuthority();
        }

        public override void OnStartClient()
        {
            if (!isLocalPlayer) return;
            PlayerData playerData;
            playerData.UserName = "Rizqy";
            playerData.Name = "Rizqy Name";
            playerData.Level = 12;
            netManager.playerTestList.Add(playerData);
            cmdUpData(playerData);
        }

        [Command]
        void cmdUpData(PlayerData playerData)
        {
            
            return;
        }
    }
}
