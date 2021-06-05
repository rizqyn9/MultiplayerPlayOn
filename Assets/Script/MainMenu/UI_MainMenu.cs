using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace PeplayonMainMenu
{
    public class UI_MainMenu : MonoBehaviour
    {
        [Header("Profile")]
        public Text userName;
        public Text level;
        public Text id;

        private void Start()
        {
            GameManager data = GameManager.instance;
            Debug.Log($"{data.Name}");
            userName.text = data.UserName;
            id.text = data.ID;
            level.text = data.Level.ToString();
        }
    }

}
