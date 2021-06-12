using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using PeplayonLobby;

namespace Networking
{
    public class NetPlayerManager : NetworkBehaviour
    {
        public PlayerUI playerUI;

        public SyncList<string> onlinePlayerStr = new SyncList<string>();
        public SyncList<PlayerShared> onlinePlayer = new SyncList<PlayerShared>();
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
            playerUI.UpdateUI();
        }

        public override void OnStartClient()
        {
        }
    }
}
