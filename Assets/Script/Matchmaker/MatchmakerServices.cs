using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Matchmaker
{
    public class MatchmakerServices : MonoBehaviour
    {
        public bool isLoading = false;

        HttpClient client = new HttpClient();

        public Room GetRequest(string reqURL)
        {
            Debug.Log("Create Request");
            HttpResponseMessage response = client.GetAsync(reqURL).GetAwaiter().GetResult();
            Debug.Log(response.ToString());
            string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Debug.Log(responseStr);
            Room responseJSON = JsonConvert.DeserializeObject<Room>(responseStr);
            Debug.Log(responseJSON.RoomID);

            //Checking Success
            if (response.IsSuccessStatusCode)
            {
                isLoading = false;
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Err");
            }
            return responseJSON;

        }

        public Room ReqMatchPublic(string baseURL)
        {
            Debug.Log("CreatePublic");
            return GetRequest($"{baseURL}/createPublic");
        }

        public Room ReqMatchPrivate(string baseURL)
        {
            Debug.Log("Create Private");
            return GetRequest($"{baseURL}/createPrivate");
        }

        public Room ReqMatchAuto(string baseURL)
        {
            Debug.Log($"Join to Random");
            return GetRequest($"{baseURL}/find");
        }

        public Room ReqMatchJoin(string baseURL, string _roomID)
        {
            Debug.Log($"Join to {_roomID}");
            return GetRequest($"{baseURL}/join/{_roomID}");
        }

        public void setRoomData()
        {
            Debug.Log("Set room data");
        }

    }
}