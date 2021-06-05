using System.Collections;
using System.Collections.Generic;
using PeplayonMainMenu;
using UnityEngine;
using UnityEngine.UI;
using Matchmaker;

namespace PeplayonMainMenu
{
    public class UI_MainMenu : MonoBehaviour
    {
        [Header("Profile")]
        public Text userName;
        public Text level;
        public Text id;

        public void Start()
        {
            Debug.Log("asdasd");
            GameManager data = GameManager.instance;
            userName.text = data.UserName;
            id.text = data.ID;
            level.text = data.Level.ToString();
        }

        private void Update()
        {
            if (DevConfig.isDevMode)
            {
                GameManager data = GameManager.instance;
                userName.text = data.UserName;
                id.text = data.ID;
                level.text = data.Level.ToString();
            }
        }
    }
}
