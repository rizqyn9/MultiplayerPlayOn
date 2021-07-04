using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

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
    public CharClassType charClassType;
}

[System.Serializable]
public struct PlayerSpawnGameObject
{
    public GameObject CharSpawn;
    public GameObject CamCharSpawn;
}

/**
 * Sync data player 
 */
namespace Peplayon
{
    public class PlayerNetwork : NetworkBehaviour
    {
        [Header("debug")]
        public CharacterController characterController;
        public Guid guidAsset;
        public GameObject GOtest;
        public GameObject[] testdebug;
        public List<GameObject> GOlistDebug = new List<GameObject>();
        public List<string> stringListDebug = new List<string>();

        [Header("Player Spawn")]
        public GameObject CharSpawn;
        public GameObject CamSpawn;

        [SyncVar]
        public PlayerShared playerShared;

        [SyncVar(hook = nameof(UpdateLead))]
        public bool isLeader;
        public bool setLeader;

        [SyncVar(hook = nameof(handleCharSpawn))]
        public CharClassType charClassType = CharClassType.None;
        //public CharTypeEnum charTypeEnum = CharTypeEnum.None;

        [SyncVar]
        public PlayerSpawnGameObject playerSpawnGameObject;

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
            netPlayerManager.localGameObject = this.gameObject;
            //CmdSetModelTest(playerShared.CharID);
        }

        #region Instance Char Art
        public void handleCharSpawn(CharClassType _old, CharClassType _new)
        {
            Debug.Log($"handleCharSpawn {_new.ToString()}");
            if (CharSpawn) { Destroy(CharSpawn); }

            Debug.Log($"handleCharSpawn {_new.ToString()}");
            //PlayerCharInstance.CmdInstanceChar(_new);
            //PlayerCharInstance.SpawnChild(_new);

            PlayerCharInstance.SpawnChildClass(_new);
            /// Something wrong
            //CustomInstance(_new);
        }

        #endregion

        [Command]
        public void CmdSetPlayerSpawnData(PlayerSpawnGameObject _playerSpawnGameObject)
        {
            playerSpawnGameObject = _playerSpawnGameObject;
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

            charClassType = _playerShared.charClassType;
        }

        [ContextMenu("Cmd Test")]
        //[Command]
        public void CmdTest()
        {
            //characterController = NetworkClient.localPlayer.GetComponent<CharacterController>();
            Debug.Log(NetworkClient.connection.identity.assetId);
            Debug.Log(NetworkClient.connection.clientOwnedObjects);
            //RpcTest();
            //NetworkServer.Destroy(CharSpawn);
            //foreach(GameObject go in NetworkClient.prefabs.Values)
            //{
            //    GOlistDebug.Add(go);
            //}
            //foreach(NetworkIdentity netid in NetworkIdentity.spawned.Values)
            //{
            //    Debug.Log(netid.netId);
            //}
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
                PlayerIndex = playerIndex,
                charClassType = GameManager.instance.charClassType
            }; 
            return setUp;
        }
    }
}

