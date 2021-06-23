using System.Collections;
using System.Collections.Generic;
using PeplayonMainMenu;
using UnityEngine;
using UnityEngine.UI;
using Matchmaker;
using TMPro;

namespace PeplayonMainMenu
{
    public class UI_MainMenu : MonoBehaviour
    {
        public GameManager gameManager;

        [Header("Profile")]
        public TMP_Text userName;
        public TMP_Text level;
        public TMP_Text id;

        [Header("Matchmaker Control")]
        public UI_MatchMaking uI_MatchMaking;
        public GameObject UI_MatchmakingGO;

        public void Awake()
        {
        }

        /**
         * <summary>Call this on first set up</summary>
         */
        public void setUpProfile()
        {
            gameManager = FindObjectOfType<GameManager>();
            userName.text = gameManager.UserName;
            id.text = gameManager.ID;
            level.text = gameManager.Level.ToString();
        }

        public void StartButton()
        {

        }

    }
}
