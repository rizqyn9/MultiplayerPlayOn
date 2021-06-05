using UnityEngine;

[System.Serializable]
public class Room : MonoBehaviour
{
    public string Data { get; set; }
    public string RoomID { get; set; }
    public int Port { get; set; }
    public bool IsPublic { get; set; }
    public string[] PlayersInRoom { get; set; }

    //public string Data;
    //public string RoomID;
    //public int Port;
    //public bool IsPublic;
    //public string[] PlayersInRoom;

    //public Room(string _data, string _roomID, int _port, bool _isPublic, string[] _playersInRoom)
    //{
    //    this.Data = _data;
    //    this.RoomID = _roomID;
    //    this.Port = _port;
    //    this.IsPublic = _isPublic;
    //    this.PlayersInRoom = _playersInRoom;
    //}
}