using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;

namespace Matchmaker
{
    public class MatchmakerServices : MonoBehaviour
    {
        public bool isLoading = false;
        public Room room;

        //HttpClient client = new HttpClient();

        //public Room GetRequest(string reqURL)
        //{
        //    Debug.Log("Create Request");
        //    HttpResponseMessage response = client.GetAsync(reqURL).GetAwaiter().GetResult();
        //    Debug.Log(response.ToString());
        //    string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //    Debug.Log(responseStr);
        //    Room responseJSON = JsonConvert.DeserializeObject<Room>(responseStr);
        //    Debug.Log(responseJSON.RoomID);

        //    //Checking Success
        //    if (response.IsSuccessStatusCode)
        //    {
        //        isLoading = false;
        //        Debug.Log("Success");
        //    }
        //    else
        //    {
        //        Debug.Log("Err");
        //    }
        //    return responseJSON;

        //}

        public Room GetReqV2(string reqURL)
        {
            StartCoroutine(GetReq(reqURL));
            return room;
        }

        IEnumerator GetReq(string reqURL)
        {
            Debug.Log("Create Req");
            UnityWebRequest webRequest = UnityWebRequest.Get(reqURL);
            yield return webRequest.SendWebRequest();
#pragma warning disable CS0618 // Type or member is obsolete
            if (webRequest.isHttpError || webRequest.isNetworkError)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                Debug.Log(webRequest.error);
                yield break;
            }

            room = JsonConvert.DeserializeObject<Room>(webRequest.downloadHandler.text);
            yield return room;
        }

        public Room ReqMatchPublic(string baseURL)
        {
            Debug.Log("CreatePublic");
            return GetReqV2($"{baseURL}/createPublic");
        }

        public Room ReqMatchPrivate(string baseURL)
        {
            Debug.Log("Create Private");
            return GetReqV2($"{baseURL}/createPrivate");
        }

        public Room ReqMatchAuto(string baseURL)
        {
            Debug.Log($"Join to Random");
            return GetReqV2($"{baseURL}/find");
        }

        public Room ReqMatchJoin(string baseURL, string _roomID)
        {
            Debug.Log($"Join to {_roomID}");
            return GetReqV2($"{baseURL}/join/{_roomID}");
        }

        public void setRoomData()
        {
            Debug.Log("Set room data");
        }

    }
}