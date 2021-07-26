using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Peplayon
{
    public class PlayerCharInstance : NetworkBehaviour
    {
        public PlayerNetwork playerNetwork;

        [Command]
        public void CmdInstanceChar(CharTypeEnum charTypeEnum)
        {
            if (!FindObjectOfType<NetPlayerManager>()) return;
            //NetPlayerManager.Instance.SpawnCharModel(connectionToClient, charTypeEnum);
        }

        #region Wrong but incredibble
        /// Something wrong
        //public void CustomInstance(CharTypeEnum charTypeEnum)
        //{
        //    CharacterBase Char = CharacterSource.Instance.SelectChar(charTypeEnum);
        //    GameObject custom = Instantiate(Char.modelCharacter, transform.parent.position, Quaternion.identity);
        //    CmdCustomInstance(custom);
        //}

        //[Command]
        //public void CmdCustomInstance(GameObject gameObject)
        //{
        //    NetPlayerManager.Instance.SpawnCustom(gameObject);
        //}
        #endregion

    }
}
