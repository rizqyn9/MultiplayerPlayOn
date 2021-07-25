using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Mirror;
using PeplayonLobby;
using UnityEngine.SceneManagement;
using System;

namespace Peplayon
{
    public enum SceneStateEnum : byte
    {
        lobbyScene,
    }
    public class NetPlayerManager : NetworkBehaviour
    {
        public GameObject tempChar;
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

        [Header("LocalPlayerData")]
        public GameObject localGameObject;

        [Header("Debug")]
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
        public SyncDictionary<string, GameObject> playerPrefabDict = new SyncDictionary<string, GameObject>();
        public SyncDictionary<string, GameObject> camPlayerPrefabDict = new SyncDictionary<string, GameObject>();

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

        #region Spawn Char
        [Server]
        public void SpawnCharModel(NetworkConnection conn, CharTypeEnum charTypeEnum)
        {
            Debug.Log($"SpawnCharModel {conn.address}");
            CharacterBase characterBase = ServerSelectChar(charTypeEnum);
            GameObject gameObject = Instantiate(characterBase.modelCharacter, NetworkManagerExt.startPositions[numPlayers % 2].position, Quaternion.identity);
            //GameObject gameObjectTemp = Instantiate(tempChar, NetworkManagerExt.startPositions[numPlayers % 2].position, Quaternion.identity);
            gameObject.name = $"--Char {characterBase.nameCharacter} - {conn.connectionId}";
            NetworkServer.Spawn(gameObject, conn);
            playerPrefabDict.Add(conn.identity.netId.ToString(), gameObject);
            conn.identity.gameObject.GetComponent<PlayerNetwork>().CmdSetPlayerSpawnData(new PlayerSpawnGameObject { CharSpawn = gameObject });
        }

        //[ClientRpc]

        private CharacterBase ServerSelectChar(CharTypeEnum charTypeEnum)
        {
            CharacterBase characterBase = CharacterSource.Instance.SelectChar(charTypeEnum);
            //return Instantiate(characterBase.modelCharacter, NetworkManagerExt.startPositions[numPlayers % 2].position, Quaternion.identity, _parent);
            return characterBase;
        }

        [Server]
        public void SpawnCustom(GameObject gameObject)
        {
            NetworkServer.Spawn(gameObject);
        }

        #endregion

        #region Spawn Cam
        [Server]
        public void ServerSpawnCam(NetworkConnection conn)
        {
            Debug.Log("Spawn cam");
        }
        #endregion
    }
}
