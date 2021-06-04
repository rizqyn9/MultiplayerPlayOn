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

        public LocalDataPlayer localDataPrefab;

        private void Start()
        {
            if (isDevMode)
            {
                LocalDataPlayer localData = LocalDataPlayer.instance;
                localData.UserName = UserName;
                localData.Name = Name;
                localData.ID = ID;
                localData.Level =level;
                return;
            }
        }
    }
}
