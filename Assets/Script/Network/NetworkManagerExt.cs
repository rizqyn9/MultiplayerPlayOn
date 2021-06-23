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
            Debug.Log("Swpawn Player net");
            NetworkServer.Spawn(PlayerNetworkManager);
        }
        public override void OnServerConnect(NetworkConnection conn)
        {
            //NetworkServer.Spawn(Instantiate(spawnPrefabs.Find(prefab => prefab.name == "--PlayerUI")));
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

        public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
        {
            Debug.Log("OnClientChangeScene");
            base.OnClientChangeScene(newSceneName, sceneOperation, customHandling);
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            Debug.Log("OnClientSceneChanged");
            base.OnClientSceneChanged(conn);
        }

        public override void OnServerChangeScene(string newSceneName)
        {
            Debug.Log("OnServerChangeScene");
            base.OnServerChangeScene(newSceneName);
        }

        public override void OnServerSceneChanged(string sceneName)
        {
            Debug.Log("OnServerSceneChanged");
            base.OnServerSceneChanged(sceneName);
        }

        public override void ServerChangeScene(string newSceneName)
        {
            Debug.Log("ServerChangeScene");
            base.ServerChangeScene(newSceneName);
        }
    }
}
