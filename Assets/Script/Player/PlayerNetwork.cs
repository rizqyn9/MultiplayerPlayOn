using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

#region Struct 
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

[System.Serializable]
public struct PlayerSpawnGameObject
{
    public GameObject CharSpawn;
    public GameObject CamCharSpawn;
}
#endregion

/**
 * Sync data player 
 */
namespace Peplayon
{
    public class PlayerNetwork : NetworkBehaviour
    {

        [Header("debug")]
        public CharacterController characterController;
        public GameObject playerTemp;
        public Guid guidAsset;
        public GameObject playerModel;

        [Header("Player Spawn")]
        public GameObject CharSpawn;

        [SyncVar]
        public PlayerShared playerShared;

        [SyncVar(hook = nameof(UpdateLead))]
        public bool isLeader;
        public bool setLeader;

        [SyncVar(hook = nameof(handleCharSpawn))]
        public CharTypeEnum charTypeEnum = CharTypeEnum.None;

        [SyncVar]
        public PlayerSpawnGameObject playerSpawnGameObject;

        public int playerIndex;
        [SerializeField] Net_Lobby Net_Lobby;

        public NetPlayerManager netPlayerManager;
        public PlayerCharInstance PlayerCharInstance;
        public Transform Model;

        #region PlayerSetup
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
            netPlayerManager.localGameObject = this.gameObject;
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
        #endregion

        /// <summary>
        /// Event trigger on Global Player State
        /// </summary>
        [Client]
        public void UpdateLead(bool old, bool _new)
        {
            if (!isLocalPlayer) return;
            if (SceneManager.GetActiveScene().path != netPlayerManager.lobbyScene) return;

            Debug.Log("Net Update Lead");
            Net_Lobby = FindObjectOfType<Net_Lobby>();
            Net_Lobby.setLead(_new);
            Net_Lobby.readyForSpawnArt();
        }

        #region PlayerInstance
        public void handleCharSpawn(CharTypeEnum _old, CharTypeEnum _new)
        {
            Debug.Log("render art");
            CmdCreatePlayer();
        }

        [Command]
        public void CmdCreatePlayer()
        {
            netPlayerManager.RpcCreatePlayer();
        }

        public void SpawnCharModel()
        {
            /// return if player have playerModel
            if (playerModel != null) return;
            /// Spawn playerModel
            playerModel = Instantiate(playerTemp, transform);
        }
        
        #endregion

        [ContextMenu("Cmd Test")]
        //[Command]
        public void CmdTest()
        {
        }

        [ClientRpc]
        public void RpcTest()
        {
            CharSpawn.SetActive(false);
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

        #region Depreceated
        //public void handleCharSpawn(CharTypeEnum _old, CharTypeEnum _new)
        //{
        //    if (!isLocalPlayer) return;
        //    Debug.Log($"handleCharSpawn {_new.ToString()}");
        //    PlayerCharInstance.CmdInstanceChar(_new);
        //}
        //[Command]
        //public void CmdSetPlayerSpawnData(PlayerSpawnGameObject _playerSpawnGameObject)
        //{
        //    playerSpawnGameObject = _playerSpawnGameObject;
        //}

        #endregion
    }
}

