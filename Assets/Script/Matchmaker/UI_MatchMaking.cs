using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

namespace Matchmaker
{
    [RequireComponent(typeof(UI_MatchMaking))]
    public class UI_MatchMaking : MonoBehaviour
    {
        [Header("Canvas container")]
        public Canvas matchMakerCanvas;
        public Canvas modeMatchCanvas;
        public Canvas createMatchCanvas;
        public Canvas loadingCanvas;
        public Canvas joinCanvas;

        [Header("Button")]
        public GameObject backBtn;
        public Button StartButton;
        [SerializeField] TMP_InputField JoinField;
        //[SerializeField] Button PublicBtn;
        //[SerializeField] Button PrivateBtn;
        //[SerializeField] Button JoinBtn;
        //[SerializeField] Button AutoBtn;

        [Header("Lobby Scene")]
        [Scene] [SerializeField] string LobbyScene;

        [Header("Matchmaker")]
        [SerializeField] string baseURL = "http://localhost:3000/matchmaker";

        public void fnStartButton()
        {
            modeMatchCanvas.enabled = true;
            matchMakerCanvas.enabled = true;
        }

        public void fnCloseButton()
        {
            matchMakerCanvas.enabled = false;
            backBtn.SetActive(false);
            loadingCanvas.enabled = false;
            createMatchCanvas.enabled = false;
            joinCanvas.enabled = false;
            modeMatchCanvas.enabled = false;
        }

        public void BackBtn()
        {
            if (createMatchCanvas.isActiveAndEnabled) createMatchCanvas.enabled = false; 
            if (joinCanvas.isActiveAndEnabled) joinCanvas.enabled = false;
            backBtn.SetActive(false);
            modeMatchCanvas.enabled = true;
        }

        #region Match Mode
        public void CreateRoom()
        {
            backBtn.SetActive(true);
            modeMatchCanvas.enabled = false;
            createMatchCanvas.enabled = true;
        }

        public void JoinRoom()
        {
            backBtn.SetActive(true);
            modeMatchCanvas.enabled = false;
            joinCanvas.enabled = true;
        }

        public void QuickMatch()
        {
            modeMatchCanvas.enabled = false;
            loadingCanvas.enabled = true;
            StartAuto();
        }
        #endregion

        #region Create Room
        public void StartPublic()
        {
            Debug.Log($"Start Public");
            createMatchCanvas.enabled = false;
            loadingCanvas.enabled = true;
            Room result = GetComponent<MatchmakerServices>().ReqMatchPublic(baseURL);
            GameManager.Instance.DataRoom = result;
            loadingCanvas.enabled = false;
            createMatchCanvas.enabled = true;
            Debug.Log($"Port {result.Port}");
            //LoadGame(result);
        }

        public void StartPrivate()
        {
            createMatchCanvas.enabled = false;
            loadingCanvas.enabled = true;
            Debug.Log($"Start Private");
            Room result = GetComponent<MatchmakerServices>().ReqMatchPrivate(baseURL);
            GameManager.Instance.DataRoom = result;
            //LoadGame(result);
        }

        #endregion

        #region Join Room
        public void StartJoin()
        {
            joinCanvas.enabled = false;
            loadingCanvas.enabled = true;
            Debug.Log($"{JoinField.text}");
            Debug.Log($"Start Join");
            GetComponent<MatchmakerServices>().ReqMatchJoin(baseURL, JoinField.text);
        }
        #endregion

        #region Quick Match
        public void StartAuto()
        {
            Debug.Log($"Start Auto");
            GetComponent<MatchmakerServices>().ReqMatchPrivate(baseURL);
        }
        #endregion

        public void LoadGame(Room _room)
        {
            SceneManager.LoadSceneAsync(LobbyScene, LoadSceneMode.Single);
        }
    }
}