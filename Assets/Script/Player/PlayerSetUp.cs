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

        public PlayerShared playerShared;

        private void Awake()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
        }

        private void Start()
        {
            if (!isLocalPlayer) return;
            //GameObject go = Instantiate(NetPlayerManagerPrefab);
            //netPlayerManager = go.GetComponent<NetPlayerManager>();

            if (gameManager == null) return;
            Instantiate(PrefabPlayerUI);

            playerShared.ID = gameManager.ID;
            playerShared.Name = gameManager.Name;
            playerShared.UserName = gameManager.UserName;
            playerShared.Level = gameManager.Level;
            playerNetwork.CmdPlayerSetUp(playerShared);

            //AddToPlayerManager(playerShared);
            //SetUp();

        }

        public void SetUp()
        {
            //Debug.Log("connn"+ conn);
            AddToPlayerManager(playerShared);
        }

        [Command(requiresAuthority =false)]
        void AddToPlayerManager(PlayerShared playerShared)
        {
            netPlayerManager.onlinePlayerStr.Add(gameManager.UserName);
            netPlayerManager.onlinePlayer.Add(playerShared);
        }
    }
}
