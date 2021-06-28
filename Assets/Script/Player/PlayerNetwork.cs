using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct PlayerShared
{
    public uint NetID;
    public int PlayerIndex;
    public string ID;
    public string Name;
    public string UserName;
    public int Level;
}

/**
 * Sync data player 
 */
namespace Networking
{
    public class PlayerNetwork : NetworkBehaviour
    {
        [SyncVar]
        public PlayerShared playerShared;

        [SyncVar(hook = nameof(UpdateLead))]
        public bool isLeader;
        public bool setLeader;

        public int playerIndex;
        [SerializeField] Net_Lobby Net_Lobby;

        public NetPlayerManager netPlayerManager;


        private void Awake()
        {
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
        }

        /**
         * Set Up Player Data to Sync local player
         */
        public override void OnStartClient()
        {
            if (!isLocalPlayer) return;
            CmdPlayerSetUp(PlayerSharedSetUp());
        }

        [Client]
        public void UpdateLead(bool old, bool _new)
        {
            Debug.Log("UpdateLead");
            if (!isLocalPlayer) return;
            Debug.Log("UpdateLead");
            if (SceneManager.GetActiveScene().path != netPlayerManager.lobbyScene) return;
            Debug.Log("UpdateLead");
            Net_Lobby = FindObjectOfType<Net_Lobby>();
            Net_Lobby.setLead(_new);
        }

        public void setLead()
        {

        }

        [Command]
        public void CmdPlayerSetUp(PlayerShared _playerShared)
        {
            Debug.Log("CmdPlayerSetUp");
            playerShared = _playerShared;
            isLeader = setLeader;

            GameManager.Instance.NetID = netId;
            netPlayerManager.onlinePlayer.Add(playerShared);
            netPlayerManager.onlinePlayerDic.Add(netId, playerShared);
        }


        public PlayerShared PlayerSharedSetUp()
        {
            PlayerShared setUp = new PlayerShared
            {
                ID = GameManager.instance.ID,
                Name = GameManager.instance.Name,
                UserName = GameManager.instance.UserName,
                Level = GameManager.instance.Level,
                NetID = netId,
                PlayerIndex = playerIndex
            }; 
            return setUp;
        }
    }
}

