using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace PeplayonLobby
{
    public class LobbySpawnHandle : NetworkBehaviour
    {
        public override void OnStartClient()
        {
            Debug.Log("Lobby Spawn handle");
        }
    }
}
