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
        [SyncVar]
        public uint NetID;
        [SyncVar]
        public bool isLeader;


        [SyncVar]
        public int playerIndex = 0;


        public GameObject PrefabPlayerUI;
        public MatchManager matchManager;
        public BillboardController billboardController;

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
            if (!isLocalPlayer) return;
            GameObject playerUI = Instantiate(PrefabPlayerUI);

        }

        public override void OnStartLocalPlayer()
        {
            DontDestroyOnLoad(gameObject);
            if (!isLocalPlayer) return;
            cmdUpdateUser(GameManager.Instance.sharedPlayer, netId);
        }


        public void SetPlayer(NetworkConnection conn)
        {

        }

    //Sync Data User
        [Command]
        private void cmdUpdateUser(SharedPlayer _player, uint _netID)
        {
            netManager.DataPlayShared.Add(_player);
            UserName = _player.UserName;
            Name = _player.Name;
            Level = _player.Level;
            NetID = _netID;
            //Debug.Log(netId);
            matchManager = GameObject.FindGameObjectWithTag("MatchManager").gameObject.GetComponent<MatchManager>();
            matchManager.listDataPlayer.Add(_player);
            matchManager.playerUsername.Add(_player.UserName);
            matchManager.ListDetailPlayer.Add(_netID, _player);

            //Instance Player UI
            //billboardController = GameObject.FindGameObjectWithTag("Billboard").gameObject.GetComponent<BillboardController>();
            //billboardController.InstancePlayerUI(_player.UserName, _player.Name, _player.Level);

            PrefabPlayerUI.GetComponent<PlayerUI>().SetUpNewPlayer(this);
        }
        
    }
}