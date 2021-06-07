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
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            base.OnServerReady(conn);
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            var data = conn.connectionId.ToString();
            Debug.Log(data);
            NetList.Add(data);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            base.OnServerAddPlayer(conn);
            PlayerNetwork playerNet = conn.identity.GetComponent<PlayerNetwork>();
            Debug.Log(playerNet.UserName);
        }

    }
}
