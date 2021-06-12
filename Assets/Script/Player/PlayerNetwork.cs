using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[System.Serializable]
public struct PlayerShared
{
    public string ID;
    public string Name;
    public string UserName;
    public int Level;
}

namespace Networking
{
    public class PlayerNetwork : NetworkBehaviour
    {
        [SyncVar]
        public string UserName;
        [SyncVar]
        public string Name;
        [SyncVar]
        public string ID;
        [SyncVar]
        public int Level;
        [SyncVar]
        public bool IsLeader;

        public NetPlayerManager netPlayerManager;
        public NetPlayerUI netPlayerUI;

        public void Start()
        {
            
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            //netPlayerUI = GameObject.FindObjectOfType<NetPlayerUI>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("asdad");
                //netPlayerUI.CmdPlayerCounter();
            }
        }

        private void Awake()
        {
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
  
        }


        [Command]
        public void CmdPlayerSetUp(PlayerShared playerShared)
        {
            //Debug.Log("CmdPlayerSetUp");
            UserName = playerShared.UserName;
            Name = playerShared.Name;
            Level = playerShared.Level;
            ID = playerShared.ID;
            IsLeader = true;

            netPlayerManager.onlinePlayer.Add(playerShared);
            netPlayerManager.onlinePlayerStr.Add(playerShared.UserName);
            netPlayerManager.onlinePlayerDic.Add(playerShared.ID, playerShared);
            netPlayerManager.TotalPlayersInRoom++;
        }
    }
}

