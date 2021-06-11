using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Networking;

namespace PeplayonLobby
{
    public class PlayerSetUp : MonoBehaviour
    {
        public GameManager gameManager;
        public PlayerNetwork playerNetwork;
        public GameObject PrefabPlayerUI;

        private void Awake()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            if (gameManager == null) return;
            PlayerShared playerShared;
            playerShared.ID = gameManager.ID;
            playerShared.Name = gameManager.Name;
            playerShared.UserName = gameManager.UserName;
            playerShared.Level = gameManager.Level;

            playerNetwork.CmdPlayerSetUp(playerShared);
        }
    }
}
