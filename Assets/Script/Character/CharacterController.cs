using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Peplayon
{
    public class CharacterController : NetworkBehaviour
    {
        public GameObject localPlayer;
        public override void OnStartAuthority()
        {
            Debug.Log("OnStartAuthority");
            base.OnStartAuthority();
            NetworkClient.localPlayer.gameObject.GetComponent<PlayerNetwork>().CharSpawn = this.gameObject;
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            Debug.Log("OnStartClient");

        }

        public override int GetHashCode()
        {
            Debug.Log(base.GetHashCode().ToString());
            return base.GetHashCode();
        }
    }
}
