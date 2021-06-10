using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

namespace Networking
{

    public class PlayerUI : MonoBehaviour
    {
        public Canvas scoreboardCanvas;
        public NetworkScoreboard networkScoreboard;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Awake()
        {
        }

        private void Update()
        {
            /**
             * Scoreboard Controller
             */
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                scoreboardCanvas.enabled = true;
            } else if (Input.GetKeyUp(KeyCode.Tab))
            {
                scoreboardCanvas.enabled = false;
            }
        }

        public void SetUpNewPlayer(PlayerNetwork _player)
        {
            networkScoreboard.CmdAddingPlayer(_player);
        }
    }
}
