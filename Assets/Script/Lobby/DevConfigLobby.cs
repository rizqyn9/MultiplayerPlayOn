using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Networking;

namespace PeplayonLobby
{
    public class DevConfigLobby : DevConfig
    {
        private void Start()
        {
            if (isDevMode)
            {
                instanceGameManger();
                if (instance == enumInstance.isHost) NetworkManagerExt.singleton.StartHost();
                if (instance == enumInstance.isServer) NetworkManagerExt.singleton.StartServer();
                if (instance == enumInstance.isClient) NetworkManagerExt.singleton.StartClient();

                if (isUseRoomData)
                {
                    setRoom();
                }
            }
        }
    }
}
