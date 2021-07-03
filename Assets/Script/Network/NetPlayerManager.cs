using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Mirror;
using PeplayonLobby;
using UnityEngine.SceneManagement;
using System;

namespace Networking
{
    public enum SceneStateEnum : byte
    {
        lobbyScene,
    }
    public class NetPlayerManager : NetworkBehaviour
    {
        public static NetPlayerManager Instance;
        public Net_Lobby net_Lobby;

        #region sceneState Masih Belom bisa diterapkan
        /**
         * Rencana dapat digunakan untuk instance class every scene change
         * Jadi cuman jalan ketika scene ganti
         */
        public SceneStateEnum sceneState
        {
            get { return _sceneState; }
            set
            {
                _sceneState = value;
            }
        }
        [SerializeField] SceneStateEnum _sceneState;
        #endregion

        [Header("debug")]
        public GameObject playerTest;
        public bool localIsLeader;
        public string netID;
        public string DUmp;

        [Header("Scene Manager")]
        [Scene] public string lobbyScene;
        [Scene] public string Map1;
        [Scene] public string Map2;
        [Scene] public string Eliminated;

        [Scene]
        public string StartScene;

        /// <summary>
        /// This will handling all event when player on connected or disconnected
        /// </summary>
        [SyncVar(hook =nameof(UpdatePlayerRoomState))]
        public int numPlayers;
        public readonly SyncList<PlayerShared> onlinePlayer = new SyncList<PlayerShared>();
        public SyncDictionary<uint, PlayerShared> onlinePlayerDic = new SyncDictionary<uint, PlayerShared>();

        #region Update Start

        private void OnEnable()
        {
            NetworkManagerExt.OnPlayerStateChanged += testEvent;
        }
        private void OnDisable()
        {
            NetworkManagerExt.OnPlayerStateChanged -= testEvent;
        }
        private void Start()
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("Strat net player");
        }
        #endregion

        public void testEvent()
        {
            Debug.Log("yuhuyy");
        }

        [Command(requiresAuthority =false)]
        void UpdatePlayerRoomState(int old, int _new)
        {
            Debug.Log("Update Total room");

            if (SceneManager.GetActiveScene().path == lobbyScene)
            {
                Debug.Log("Update Total room");
                net_Lobby = FindObjectOfType<Net_Lobby>();
                net_Lobby.counter = _new;
            }
        }

        [Server]
        public void ServerHandlingPlayerDisconnect(uint _netID)
        {
            Debug.Log(_netID);
            onlinePlayerDic.Remove(_netID);
            onlinePlayer.RemoveAll(res => res.NetID == _netID);
        }

        public void SpawnCharModel(NetworkConnection conn, CharTypeEnum charTypeEnum, Transform _parent)
        {
            Debug.Log($"SpawnCharModel {conn.address}");
            NetworkServer.Spawn(ServerSelectChar(charTypeEnum, _parent), conn);
        }

        private GameObject ServerSelectChar(CharTypeEnum charTypeEnum, Transform _parent)
        {
            CharacterBase characterBase = CharacterSource.Instance.SelectChar(charTypeEnum);
            return Instantiate(characterBase.modelCharacter, NetworkManagerExt.startPositions[numPlayers % 2].position, Quaternion.identity, _parent);
        }
    }
}
