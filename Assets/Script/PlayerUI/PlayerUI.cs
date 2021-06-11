using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        private void Start()
        {
            playerCounter.text = "0";
            playerRole.text = isLeader ? "Leader" : "Member";
            RoomID.text = "Room ID";
            StartBtn.interactable = false;
        }
    }
}
