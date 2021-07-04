using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using System.Linq;

namespace Peplayon
{
    [AddComponentMenu("")]
    public class NetworkManagerExt : NetworkManager
    {
        [Header("Scene Management")]
        [SerializeField] [Scene] string LobbyScene;
        [SerializeField] [Scene] string Map_1;
        [SerializeField] [Scene] string Map_2;

        public GameObject[] listScriptDontDestroy;
        public GameObject PlayerNetworkManager;
        public NetPlayerManager netPlayerManager;

        /// <summary>
        /// Event for handling PlayerState
        /// </summary>
        public static Action OnPlayerStateChanged;

        public int playerIndex = 1;

        private void Start()
        {
            /// Load resources Spawnable
            spawnPrefabs.AddRange(Resources.LoadAll<GameObject>("Prefab/Spawnable").ToList());
            /// Load resources Character Prefab
            spawnPrefabs.AddRange(Resources.LoadAll<GameObject>("Prefab/Character").ToList());
        }

        #region SERVER CALLBACK
        public override void OnStartServer()
        {
            base.OnStartServer();
            ///Spawn NetPlayerManager
            PlayerNetworkManager = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "--PlayerNetworkManager"));
            //Debug.Log("Spawn Player net");
            NetworkServer.Spawn(PlayerNetworkManager);
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            Debug.Log("OnServerReady");
            base.OnServerReady(conn);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            //Debug.Log("OnServerAddPlayer");
            if(SceneManager.GetActiveScene().path == LobbyScene)
            {
                GameObject player = Instantiate(playerPrefab);
                player.name = $"--Player-{conn.connectionId}";
                PlayerNetwork playerNetwork = player.GetComponent<PlayerNetwork>();

                /// Set first player as default leader
                if (numPlayers == 0) playerNetwork.setLeader = true;
                playerNetwork.playerIndex = playerIndex;
                NetworkServer.AddPlayerForConnection(conn, player);
            }

            /// Update state inner Netplayermanager / can use like event player OnDisconnected / OnConnected
            NetPlayerManager.Instance.numPlayers = numPlayers;
            playerIndex++;
        }

        public override void OnServerSceneChanged(string sceneName)
        {
            Debug.Log("OnServerSceneChanged");
            base.OnServerSceneChanged(sceneName);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            Debug.Log("OnServerDisconnect");
            if(conn.identity != null)
            {
                var player = conn.identity.netId;
                Debug.Log(player);
                NetPlayerManager.Instance.ServerHandlingPlayerDisconnect(player);
            }
            NetPlayerManager.Instance.numPlayers = numPlayers;
            base.OnServerDisconnect(conn);
        }

        #endregion

        #region CLIENT CALLBACK
        public override void OnStartClient()
        {
            Debug.Log("Net Manager start client");
            base.OnStartClient();
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
            OnPlayerStateChanged?.Invoke();
        }

        public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
        {
            Debug.Log("OnClientChangeScene");
            base.OnClientChangeScene(newSceneName, sceneOperation, customHandling);
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            Debug.Log("OnClientSceneChanged");
            base.OnClientSceneChanged(conn);
            netPlayerManager = FindObjectOfType<NetPlayerManager>();

        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);
            Debug.Log("OnClientDisconnect");
            //OnPlayerStateChanged?.Invoke();

        }

        public override void OnStopClient()
        {
            base.OnStopClient();
        }
        #endregion


        public override void OnServerChangeScene(string newSceneName)
        {
            Debug.Log("OnServerChangeScene");
            base.OnServerChangeScene(newSceneName);
        }


        public override void ServerChangeScene(string newSceneName)
        {
            Debug.Log("ServerChangeScene");
            base.ServerChangeScene(newSceneName);
        }

        #region Start Handling
        public void ServerStartGame()
        {
            ServerChangeScene(Map_1);
        }
        #endregion
    }
}
