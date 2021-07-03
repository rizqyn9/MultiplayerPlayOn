using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public struct PlayerShared
{
    public uint NetID;
    public int PlayerIndex;
    public string ID;
    public string Name;
    public string UserName;
    public int Level;
    public CharTypeEnum CharType;
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

        //[SyncVar(hook =nameof(handleCharSpawn))]
        public int CharID;

        [SyncVar(hook = nameof(handleCharSpawn))]
        public CharTypeEnum charTypeEnum = CharTypeEnum.None;

        public int playerIndex;
        [SerializeField] Net_Lobby Net_Lobby;

        public NetPlayerManager netPlayerManager;
        public PlayerCharInstance PlayerCharInstance;
        public Transform Model;

        private void Awake()
        {
            netPlayerManager = GameObject.FindObjectOfType<NetPlayerManager>();
        }

        /**
         * Set Up Player Data to Sync local player with server
         */
        public override void OnStartClient()
        {
            if (!isLocalPlayer) return;
            CmdPlayerSetUp(PlayerSharedSetUp());
            //CmdSetModelTest(playerShared.CharID);
        }

        [Command(requiresAuthority =true)]
        private void CmdSetModelTest(int charID, NetworkConnectionToClient sender = null)
        {
            NetworkServer.Spawn(PlayerCharInstance.SpawnChar(charID), sender);
        }


        public void handleCharSpawn(CharTypeEnum _old, CharTypeEnum _new)
        {
            if (!isLocalPlayer) return;
            Debug.Log($"handleCharSpawn {_new.ToString()}");
            //CmdInstanceChar(_new);
            CmdInstanceChar2(_new);
        }

        [Command]
        private void CmdInstanceChar2(CharTypeEnum charTypeEnum)
        {
            Debug.Log("CmdInstanceChar2");
            NetPlayerManager.Instance.SpawnCharModel(connectionToClient, charTypeEnum, Model);
        }

        [Command]
        public void CmdInstanceChar(int charID, NetworkConnectionToClient sender = null)
        {
            NetworkServer.Spawn(PlayerCharInstance.SpawnChar(charID), sender);
        }

        [Client]
        public void UpdateLead(bool old, bool _new)
        {
            if (!isLocalPlayer) return;
            if (SceneManager.GetActiveScene().path != netPlayerManager.lobbyScene) return;

            Net_Lobby = FindObjectOfType<Net_Lobby>();
            Net_Lobby.setLead(_new);
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

            charTypeEnum = _playerShared.CharType;
        }


        public PlayerShared PlayerSharedSetUp()
        {
            PlayerShared setUp = new PlayerShared
            {
                ID = GameManager.instance.ID,
                Name = GameManager.instance.Name,
                UserName = GameManager.instance.UserName,
                Level = GameManager.instance.Level,
                CharType = GameManager.instance.CharID,
                NetID = netId,
                PlayerIndex = playerIndex
            }; 
            return setUp;
        }
    }
}

