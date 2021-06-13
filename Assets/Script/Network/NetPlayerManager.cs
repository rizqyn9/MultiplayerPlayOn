using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Mirror;
using PeplayonLobby;
using UnityEngine.SceneManagement;

namespace Networking
{
    public class NetPlayerManager : NetworkBehaviour
    {
        [Scene] [SerializeField]
        public string StartScene;
        public PlayerUI playerUI;

        public SyncList<string> onlinePlayerStr = new SyncList<string>();
        public SyncList<PlayerShared> onlinePlayer = new SyncList<PlayerShared>();
        public SyncList<string> OnlineNetID = new SyncList<string>();
        public SyncDictionary<string, PlayerShared> onlinePlayerDic = new SyncDictionary<string, PlayerShared>();

        // Event for Join player or Leaved Player
        [SyncVar(hook = nameof(UpdatePlayerRoomState))]
        public int TotalPlayersInRoom = 0;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void UpdatePlayerRoomState(int old, int _new)
        {
            playerUI = GameObject.FindObjectOfType<PlayerUI>();
            //playerUI.UpdateUI(onlinePlayer[0].NetID);
            playerUI.UpdateUI(OnlineNetID[0]);
        }

        public override void OnStartClient()
        {
        }

        public override void OnStopClient()
        {
            //PlayerUI go = GameObject.FindObjectOfType<PlayerUI>();
            //Destroy(go.gameObject);
        }

        [ClientRpc]
        public void RpcStartGamae()
        {
            Debug.Log("rpc Scene");
            SceneManager.LoadScene(StartScene, LoadSceneMode.Single);
        }
    }
}
