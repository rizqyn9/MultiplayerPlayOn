using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Networking;

public class NetworkScoreboard : NetworkBehaviour
{
    public SyncDictionary<string, PlayerNetwork> listPlayerData = new SyncDictionary<string, PlayerNetwork>();
    public SyncList<string> playerOnlineStr = new SyncList<string>();

    //[Command]
    public void CmdAddingPlayer(PlayerNetwork playerNetwork)
    {
        listPlayerData.Add(playerNetwork.Name, playerNetwork);
        playerOnlineStr.Add(playerNetwork.Name);
    }
}
