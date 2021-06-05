using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;
using System.Net.Http;
using UnityEditor;

namespace Matchmaker
{
    [RequireComponent(typeof(UI_MatchMaking))]
    public class UI_MatchMaking : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] Button PublicBtn;
        [SerializeField] Button PrivateBtn;
        [SerializeField] Button JoinBtn;
        [SerializeField] Button AutoBtn;
        [SerializeField] InputField JoinField;


        [Header("Lobby Scene")]
        [Scene] [SerializeField] string LobbyScene;

        [Header("Matchmaker")]
        [SerializeField] string baseURL = "http://localhost:3000/matchmaker";
        HttpClient client = new HttpClient();

        public void StartPublic()
        {
            Debug.Log($"Start Public");
            Room result = GetComponent<MatchmakerServices>().ReqMatchPublic(baseURL);
            GameManager.Instance.DataRoom = result;
            Debug.Log($"Port {result.Port}");
            //LoadGame(result);
        }

        public void StartPrivate()
        {
            Debug.Log($"Start Private");
            Room result = GetComponent<MatchmakerServices>().ReqMatchPrivate(baseURL);
            GameManager.Instance.DataRoom = result;
            //LoadGame(result);
        }

        public void StartJoin()
        {
            Debug.Log($"{JoinField.text}");
            Debug.Log($"Start Join");
            GetComponent<MatchmakerServices>().ReqMatchJoin(baseURL, JoinField.text);
        }

        public void StartAuto()
        {
            Debug.Log($"Start Auto");
            GetComponent<MatchmakerServices>().ReqMatchPrivate(baseURL);
        }

        public void LoadGame(Room _room)
        {
            SceneManager.LoadSceneAsync(LobbyScene, LoadSceneMode.Single);
        }
    }
}