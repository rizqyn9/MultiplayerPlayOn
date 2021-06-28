using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;
using Networking;

namespace PeplayonLobby
{
    public class UI_Lobby : MonoBehaviour
    {
        public GameManager gameManager;
        [SerializeField] GameObject startBtn;

        [Header("Serialized")]
        public TMP_Text playerCounter;
        public TMP_Text playerMax;
        public TMP_Text roomID;


        /**<summary>
         * First instance for Lobby UI
         * </summary>
         */
        public void setUpLobbyUI()
        {
            playerMax.text = NetworkManager.singleton.maxConnections.ToString();
            gameManager = FindObjectOfType<GameManager>();
        }

        public void updatePlayerCounter(int counter)
        {
            playerCounter.text = counter.ToString();
        }

        public void checkLeader(bool isLeader)
        {
            Debug.Log($"Update Leader is {isLeader}");
            startBtn.SetActive(isLeader);
        }
    }
}
