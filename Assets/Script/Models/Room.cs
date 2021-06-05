using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Room
{
    public string Data;
    public string RoomID;
    public int Port;
    public bool IsPublic;
    public string[] PlayersInRoom;
}
