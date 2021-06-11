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



    }
}
