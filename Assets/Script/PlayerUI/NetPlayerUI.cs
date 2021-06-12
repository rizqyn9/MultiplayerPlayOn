using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using PeplayonLobby;

namespace Networking
{
    public class NetPlayerUI : NetworkBehaviour
    {
        public PlayerUI playerUI;

        [SyncVar(hook =nameof(OnCounterChnage))]
        public int PlayerCounter = 0;
        [SyncVar]
        public bool isLeader;

        private void Update()
        {
        }

        [Command(requiresAuthority =false)]
        public void CmdPlayerCounter()
        {
            Debug.Log("asdasdasda");
            PlayerCounter++;
            Debug.Log(PlayerCounter);
        }

        void OnCounterChnage(int _old, int _new)
        {
            Debug.Log("jgdfjghjdkfg");
            playerUI.playerCounter.text = _new.ToString();
        }
        public void NetSetUp()
        {

        }
    }
}
