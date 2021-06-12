using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Serialization;
using PeplayonLobby;

namespace Networking
{
    [AddComponentMenu("")]
    public class NetworkManagerExt : NetworkManager
    {
        public GameObject[] listScriptDontDestroy;
        public GameObject PlayerNetworkManager;


        public override void OnStartServer()
        {
            base.OnStartServer();
            PlayerNetworkManager = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "--PlayerNetworkManager"));
            NetworkServer.Spawn(PlayerNetworkManager);
        }
        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);


        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            base.OnServerAddPlayer(conn);
            //PlayerSetUp playerSetUp = conn.identity.GetComponent<PlayerSetUp>();
            //playerSetUp.SetUp(conn.connectionId);

        }

    }
}
