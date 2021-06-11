using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeplayonLobby
{
    public class DevConfigLobby : MonoBehaviour
    {
        [Header("CUSTOM DATA PLAYER")]
        [SerializeField] string Name = "Rizqy";
        [SerializeField] string ID = "index1";
        [SerializeField] string UserName = "PlayerKill";
        [SerializeField] int level = 2;

        public bool isDevMode = true;
        public GameObject gameManager;
        private void Start()
        {
            if (isDevMode)
            {
                Instantiate(gameManager);
                Debug.Log("Running as Dev");
                GameManager localData = GameManager.instance;
                localData.UserName = UserName;
                localData.Name = Name;
                localData.ID = ID;
                localData.Level = level;
                Debug.Log(GameManager.Instance.UserName);

            }
        }
    }
}
