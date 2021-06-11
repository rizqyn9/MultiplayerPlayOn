using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Networking
{
    public class NetPlayerManager : NetworkBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
