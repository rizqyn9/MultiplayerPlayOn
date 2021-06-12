using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Networking;

namespace PeplayonLobby
{
    public class PlayerUI : MonoBehaviour
    {
        public Text playerCounter;
        public Text playerRole;
        public Text RoomID;
        public Button ExitMenuBtn;
        public Button StartBtn;
        public bool isLeader;
        public NetPlayerManager netPlayerManager;

        private void Start()
        {

            //playerCounter.text = "0";
            playerRole.text = isLeader ? "Leader" : "Member";
            RoomID.text = "Room ID";
            StartBtn.interactable = false;
        }

        private void Awake()
        {
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
        }

        public void UpdateUI()
        {
                string data = netPlayerManager.onlinePlayer.Count.ToString();
            Debug.Log(data);
            playerCounter.text = data;
            
        }

        public void SetUp(PlayerShared playerShared)
        {

        }
    }
}
