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
        public PlayerNetwork playerNetwork;
        public string NetID = "";

        private void Start()
        {
            RoomID.text = "Room ID";
        }

        private void Awake()
        {
            Debug.Log("find");
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
        }

        private void OnEnable()
        {
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
        }
        /**
         * <param name="playerShared">For Compare Leader in Room</param>
         * 
         */
        public void UpdateUI(string _NetID)
        {
            Debug.Log("UpdateUI");
            NetID = GameManager.Instance.NetID;

            isLeader = CheckLeader(GameManager.Instance.NetID, _NetID);
            string data = netPlayerManager.onlinePlayer.Count.ToString();
            playerCounter.text = data;
            playerRole.text = isLeader ? "Leader" : "Member";
            //StartBtn.enabled = isLeader;

        }

        //Checking Leader Player
        bool CheckLeader(string Local, string Leader)
        {
            Debug.Log("chechk leader");
            bool result = Local == Leader ? true : false;
            return result;
        }

        public void SetUp(PlayerShared playerShared)
        {

        }

        public void StartGame()
        {
            Debug.Log("Start Game");
            playerNetwork.CmdStartGame();
        }

        public void Test()
        {
            Debug.Log("Test");
        }
    }
}
