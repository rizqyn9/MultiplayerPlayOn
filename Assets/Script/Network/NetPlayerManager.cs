using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Networking
{
    public class NetPlayerManager : NetworkBehaviour
    {
        public SyncList<string> onlinePlayerStr = new SyncList<string>();
        public SyncList<PlayerShared> onlinePlayer = new SyncList<PlayerShared>();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
