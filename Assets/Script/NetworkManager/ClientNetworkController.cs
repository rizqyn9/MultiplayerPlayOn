using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClientNetworkController : MonoBehaviour
{
    public List<string> PlayersInRoom = new List<string>();
    //SyncList<string> lsit = new SyncList<string>();
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void onConnectedClient(NetworkConnection conn)
    {
        PlayersInRoom.Add(conn.connectionId.ToString());
    }
    public void onDisconnectedClient(NetworkConnection conn)
    {
        PlayersInRoom.Remove(conn.connectionId.ToString());
    }
}
