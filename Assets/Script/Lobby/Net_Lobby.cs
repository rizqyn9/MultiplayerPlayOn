using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using PeplayonLobby;

namespace Peplayon
{
    public class Net_Lobby : NetworkBehaviour
    {
        public UI_Lobby uI_Lobby;
        public LobbySpawnHandle lobbySpawnHandle;
        public NetworkManagerExt _networkManager;
        public NetPlayerManager netPlayerManager;

        [SyncVar(hook =nameof(UpdateUI))]
        public int counter = 0;

        public override void OnStartClient()
        {
            //Debug.Log("Net_Lobby");
            uI_Lobby.setUpLobbyUI();
        }
        #region Server Callback
        [Command(requiresAuthority =false)]
        public void CmdStartGame()
        {
            _networkManager.ServerStartGame();
        }
        #endregion

        #region Client callback

        [Client]
        void UpdateUI(int _old, int _new)
        {
            //Debug.Log("Update UI");
            uI_Lobby.updatePlayerCounter(_new);
        }

        public void setLead(bool islead)
        {
            uI_Lobby.checkLeader(islead);
        }

        [Client]
        public void readyForSpawnArt()
        {
            Debug.Log("readyForSpawnArt");
            lobbySpawnHandle.spawnChar();
        }

        #endregion
    }
}
