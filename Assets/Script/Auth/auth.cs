using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Net.Http;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;
using System.Text;

namespace PeplayonAuth
{
    public class auth : MonoBehaviour
    {
        /** Check ID player ready / Ticket Session
         * false => show container auth
         * true => bring player to next scene
         * 
         */

        [Header("Net Server")]
        public string baseURL = "http://localhost:3000/api";
        public string playerID = "";
        public bool isAuthenticated = false;

        [Scene]
        public string MainMenuScene = null;

        [Header("Log In")]
        [SerializeField] public Canvas CanvasLogin;
        [SerializeField] public InputField Username;
        [SerializeField] public InputField PassLogin;
        [SerializeField] public Button LoginBtn;


        [Header("Sign Up")]
        [SerializeField] public Canvas CanvasSignup;
        [SerializeField] public InputField NameSignup;
        [SerializeField] public InputField UsernameSignup;
        [SerializeField] public InputField PassSignup;
        [SerializeField] public Button SignupBtn;

        [Header("Input Field")]
        [SerializeField] public InputField[] ArrInput;

        [Header("Loading")]
        [SerializeField] public Canvas CanvasLoading;
        public bool isLoading = true;

        //public LocalDataPlayer localDataPlayer = new LocalDataPlayer();

        HttpClient client = new HttpClient();

        public void Update()
        {
            if (isLoading)
            {
                CanvasLoading.enabled = true;
            } else
            {
                CanvasLoading.enabled = false;

            }
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("ID"))
            {
                playerID = PlayerPrefs.GetString("ID");
                Debug.Log(playerID);
                Debug.Log(PlayerPrefs.GetString("UserName"));
                Debug.Log(PlayerPrefs.GetString("Name"));
                HttpResponseMessage response = client.GetAsync(baseURL + "/getdata" + $"/{playerID}").GetAwaiter().GetResult();
                string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Debug.Log(responseStr);
                Response responseJSON = JsonConvert.DeserializeObject<Response>(responseStr);
                if (response.IsSuccessStatusCode)
                {
                    isLoading = false;
                    //Test
                    isAuthenticated = true;
                    SetPlayerData(responseJSON);
                    SaveTicketID(responseJSON._id);
                    //Debug.Log("Success");
                    //SceneSuccess();
                }
                else
                {
                    Debug.Log("Err");
                }
            }
            else
            {
                isLoading = false;
                CanvasLogin.enabled = true;
            }
        }

        #region UI Handling

        public void toSignUp()
        {
            CanvasLogin.enabled = false;
            CanvasSignup.enabled = true;
        }

        public void toLogin()
        {
            CanvasSignup.enabled = false;
            CanvasLogin.enabled = true;
        }

        #endregion

        public void SignUp()
        {
            Debug.Log("Sign Up");
            isLoading = true;
            POST SignUp_Data = new POST(NameSignup.text, UsernameSignup.text, PassSignup.text);
            var FormSignUp = new StringContent(SignUp_Data.ToJSON(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseURL + "/signup", FormSignUp).GetAwaiter().GetResult();
            string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Debug.Log(responseStr);

            Response responseJSON = JsonConvert.DeserializeObject<Response>(responseStr);
            Debug.Log(responseJSON._id);

            //Checking Success
            if (response.IsSuccessStatusCode)
            {
                isLoading = false;
                Debug.Log("Success");
                toLogin();
            }
            else
            {
                Debug.Log("Err");
            }
        }

        public void Login()
        {
            Debug.Log("Login");
            POST SignIn_Data = new POST(null, Username.text, PassLogin.text);
            Debug.Log(Username.text);
            Debug.Log(PassLogin.text);
            var FormSignIn = new StringContent(SignIn_Data.ToJSON(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseURL + "/signin", FormSignIn).GetAwaiter().GetResult();
            string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Debug.Log(responseStr);
            Response responseJSON = JsonConvert.DeserializeObject<Response>(responseStr);
            isAuthenticated = true;
            //Test
            //LocalPlayerData contoh = new LocalPlayerData("idasd", "Rizqy", 12);
            //Checking Success
            if (response.IsSuccessStatusCode)
            {
                SetPlayerData(responseJSON);
                SaveTicketID(responseJSON._id);
                Debug.Log("Success");
                SceneSuccess();
            }
            else
            {
                Debug.Log("Err");
            }
        }

        void SaveTicketID(string _id)
        {
            Debug.Log("Auth --> Save ID");
            playerID = _id;
            PlayerPrefs.SetString("ID", _id);
        }

        void SceneSuccess()
        {
            SceneManager.LoadScene(MainMenuScene, LoadSceneMode.Single);
        }

        public void SetPlayerData(Response _data)
        {
            PlayerPrefs.SetString("Name", _data.Name);
            PlayerPrefs.SetString("UserName", _data.UserName);
            PlayerPrefs.SetString("PlayerID", _data.PlayerID);


            //LocalDataPlayer data = LocalDataPlayer.instance;
            //data.UserName = _data.UserName;
            //data.Name = _data.Name;
            //data.ID= _data._id;
            //data.Level = _data.Level;


            GameManager gameManager =  GameManager.instance;
            User dataUser;
            dataUser.ID = _data._id;
            dataUser.UserName = _data.UserName;
            dataUser.Name = _data.Name;
            dataUser.Level = _data.Level;
            gameManager.DataLocalUser = dataUser;
        }
    }

    public struct Response
    {
        public string _id;
        public string Name;
        public string UserName;
        public string PlayerID;
        public int Level;
        public object Character;

    }

    public class POST
    {
        public string ID;
        public string Name;
        public string UserName;
        public string Password;


        public POST(string Name, string UserName, string Password, string ID = null)
        {
            this.ID = ID;
            this.Name = Name;
            this.UserName = UserName;
            this.Password = Password;
        }

        public string ToJSON()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
