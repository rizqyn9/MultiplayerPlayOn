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
            Debug.Log($"Port {result.Port}");
        }

    }
}
