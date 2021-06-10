using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Networking
{
    [AddComponentMenu("")]
    public class NetworkManagerExt : NetworkManager
    {
        [Header("Custom Manager")]
        public GameObject matchManager;
        public GameObject Billboard;
        public ClientNetworkController clientNetworkController;

        public static List<PlayerNetwork> playerNet = new List<PlayerNetwork>();

        [SerializeField]
        public static List<string> NameList = new List<string>();

        [SerializeField]
        public List<string> NetList = new List<string>();

        [SerializeField]
        public List<PlayerData> playerTestList = new List<PlayerData>();

        [SerializeField]
        public List<SharedPlayer> DataPlayShared = new List<SharedPlayer>();

        [Header("DEBUGGER")]
        public int PlayerListCount = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerListCount = DataPlayShared.Count;
            }
        }

        public override void OnStartServer()
        {
            Debug.Log("Starting Server");
            base.OnStartServer();
            GameObject go = Instantiate(matchManager);
            NetworkServer.Spawn(go);

            //Billboard = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Billboard"));
            //NetworkServer.Spawn(Billboard);
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            base.OnServerReady(conn);
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            var data = conn.connectionId.ToString();
            NetList.Add(data);
            clientNetworkController.onConnectedClient(conn);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            base.OnServerAddPlayer(conn);
            //PlayerNetwork playerNet = conn.identity.GetComponent<PlayerNetwork>();
            //playerNet.SetPlayer(conn);
            //playerNet.playerIndex = numPlayers;
        }

        //public override void OnClientConnect(NetworkConnection conn)
        //{
        //    base.OnClientConnect(conn);
        //}

        public override void OnServerChangeScene(string newSceneName)
        {
            Debug.Log("OnServerChangeScene");
            base.OnServerChangeScene(newSceneName);
        }

        public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
        {
            base.OnClientChangeScene(newSceneName, sceneOperation, customHandling);
            Debug.Log("OnClientChangeScene");
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            base.OnClientSceneChanged(conn);
            Debug.Log("OnClientSceneChanged");
            //Debug.Log(playerNet.playerIndex);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            clientNetworkController.onDisconnectedClient(conn);
        }
    }
}
