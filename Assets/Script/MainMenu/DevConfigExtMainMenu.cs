using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PeplayonMainMenu
{
    [AddComponentMenu("")]
    public class DevConfigExtMainMenu : DevConfig
    {
        [Header("CUSTOM DATA PLAYER")]
        [SerializeField] string Name = "Rizqy";
        [SerializeField] string ID = "index1";
        [SerializeField] string UserName = "PlayerKill";
        [SerializeField] int level = 2;

        public GameManager localDataPrefab;

        private void Start()
        {
            if (isDevMode)
            {
                GameManager localData = GameManager.instance;
                localData.UserName = UserName;
                localData.Name = Name;
                localData.ID = ID;
                localData.Level = level;
                return;
            }
        }
    }
}
