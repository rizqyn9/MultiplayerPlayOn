using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

namespace Peplayon
{
    public class PlayerCharInstance : NetworkBehaviour
    {
        public PlayerNetwork playerNetwork;
        public GameObject model;
        public CharacterBase CharacterBase;
        public CharacterClass characterClass;

        private void Awake()
        {
            playerNetwork = GetComponent<PlayerNetwork>();
        }

        [Command]
        public void CmdInstanceChar(CharTypeEnum charTypeEnum)
        {
            if (!FindObjectOfType<NetPlayerManager>()) return;
            NetPlayerManager.Instance.SpawnCharModel(connectionToClient, charTypeEnum);
        }

        public void SpawnChild(CharTypeEnum charTypeEnum)
        {
            CharacterBase characterBase = CharacterSource.Instance.SelectChar(charTypeEnum);
            GameObject gameObject = Instantiate(characterBase.modelCharacter, transform.position, Quaternion.identity, model.transform);
            playerNetwork.CharSpawn = gameObject;
        }

        #region Wrong but incredibble
        /// Something wrong
        //public void CustomInstance(CharTypeEnum charTypeEnum)
        //{
        //    CharacterBase Char = CharacterSource.Instance.SelectChar(charTypeEnum);
        //    GameObject custom = Instantiate(Char.modelCharacter, transform.parent.position, Quaternion.identity);
        //    CmdCustomInstance(custom);
        //}

        [Command]
        public void CmdCustomInstance(GameObject gameObject)
        {
            NetPlayerManager.Instance.SpawnCustom(gameObject);
        }
        #endregion

        public void SpawnChildClass(CharClassType @new)
        {
            characterClass = CharacterSource.Instance.SelectCharClass(@new);
            GameObject gameObject = Instantiate(characterClass.playerObject, transform.position, Quaternion.identity, model.transform);
            playerNetwork.CharSpawn = gameObject;
        }

    }
}
