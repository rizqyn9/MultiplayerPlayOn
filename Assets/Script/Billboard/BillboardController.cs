using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

namespace Networking
{
    public class BillboardController : NetworkBehaviour
    {
        public MatchManager matchManager;
        public Canvas billCanvas;
        public Transform UIPlayerParents;
        public GameObject PrefabPlayerUI;

        public SyncList<PlayerNetwork> ListBillboardPlayers = new SyncList<PlayerNetwork>();

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        //public void InstancePlayerUI(string _name, string _id, int _level)
        //{
        //    GameObject go = Instantiate(PrefabPlayerUI, UIPlayerParents)
        //    NetworkServer.Spawn();
        //}

        public void UpdateDisplay()
        {

            //matchManager = GameObject.FindGameObjectWithTag("MatchManager").gameObject.GetComponent<MatchManager>();
            //Debug.Log($"===={matchManager.ListDetailPlayer.Count}");
            //for(var i = 0; i < matchManager.ListDetailPlayer.Count; i++)
            //{
            //    GameObject instance = Instantiate(PrefabPlayerUI, UIPlayerParents);
            //    instance.transform.SetSiblingIndex(i);
            //}
            //foreach (SharedPlayer _player in matchManager.ListDetailPlayer.Values)
            //{
            //    GameObject instance = Instantiate(PrefabPlayerUI, UIPlayerParents);
            //    instance.transform.SetSiblingIndex()
            //}
        }

        public void DestroyDisplay()
        {

        }

        public void InstancePlayer(SharedPlayer _player)
        {

        }

        void Update()
        {
            //if (!isLocalPlayer) return;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (billCanvas.isActiveAndEnabled)
                {
                    //UpdateDisplay();
                    billCanvas.enabled = true;
                } else
                {
                    billCanvas.enabled = false;

                }
            }
        
        }
    }
}
