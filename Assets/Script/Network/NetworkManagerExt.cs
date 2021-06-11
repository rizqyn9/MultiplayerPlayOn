using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Serialization;

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
            GameObject go = Instantiate(PlayerNetworkManager);
            NetworkServer.Spawn(go);
        }
        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);


        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
            //PlayerNetworkManager = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "--PlayerNetworkManager"));
            //NetworkServer.Spawn(PlayerNetworkManager,conn);
            //GameObject go = Instantiate(PlayerNetworkManager);
            //NetworkServer.Spawn(go);

        }
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            base.OnServerAddPlayer(conn);

        }

    }
}
