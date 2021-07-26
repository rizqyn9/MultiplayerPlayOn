using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace PeplayonLobby
{
    public class LobbySpawnHandle : NetworkBehaviour
    {
        public GameObject localPlayer;
        public override void OnStartClient()
        {
            //Debug.Log("Lobby Spawn handle");
        }

        public void spawnChar()
        {
            localPlayer = NetworkClient.localPlayer.gameObject;
            Debug.Log("Spawn Char");
        }
    }
}
