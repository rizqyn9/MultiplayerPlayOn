using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Networking;
using Mirror;

namespace PeplayonLobby
{
    public class PlayerSetUp : NetworkBehaviour
    {
        public GameObject PrefabPlayerUI;
        public PlayerNetwork playerNetwork;
        public GameObject NetPlayerManagerPrefab;

        [SerializeField] GameManager gameManager;
        [SerializeField] NetPlayerManager netPlayerManager;
        [SerializeField] PlayerUI playerUI;

        public PlayerShared playerShared;

        private void Awake()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
            playerUI = GameObject.FindObjectOfType<PlayerUI>();
        }

        private void Start()
        {
            if (!isLocalPlayer) return;

            if (gameManager == null) return;
            //Instantiate(PrefabPlayerUI);
            playerUI.playerNetwork = this.playerNetwork;
            playerShared.ID = gameManager.ID;
            playerShared.Name = gameManager.Name;
            playerShared.UserName = gameManager.UserName;
            playerShared.Level = gameManager.Level;
            playerShared.NetID = netId.ToString();
            playerNetwork.CmdPlayerSetUp(playerShared);
            
        }
    }
}
