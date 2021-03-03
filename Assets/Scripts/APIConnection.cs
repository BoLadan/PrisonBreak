using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{
    private string authKey = "323ccac15d8c7ab9ce00f9e69320d48015d2eb89";
    private string gamerTag;
    private string gameName;
    private string gameId;

    IEnumerator GetRequest(string url)
    {
        // this pauses the webrequest untill the request returns
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("X-AUTH", authKey);
            yield return webRequest.SendWebRequest();

            //check for connection error or show result if success
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Success");
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    gamerTag = JsonObject["gamertag"].Value;
                    Debug.Log("Check out my name: " + gamerTag);
                    StartCoroutine(GetGameId("https://xapi.us/v2/2535439706856428/xboxonegames"));
                    ////'.Value' zorgt ervoor dat het een string word.
                    //Debug.Log("Check out this amazing joke: " + JsonObject["value"]["joke"].Value);
                    //Debug.Log("the ID of the joje is: " + JsonObject["value"]["ID"].AsInt);

                    break;
            }
        }
    }

    IEnumerator GetGameId(string url)
    {
        // this pauses the webrequest untill the request returns
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("X-AUTH", authKey);
            yield return webRequest.SendWebRequest();

            //check for connection error or show result if success
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Success");
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    Debug.Log("Test: " + JsonObject["titles"]["name"].Value);

                    //gameName = JsonObject["name"].Value;
                    //gameId = JsonObject["titleId"].Value;
                    //Debug.Log("the name of the game you seek is: " + gameName + " and its ID is: " + gameId);

                    ////'.Value' zorgt ervoor dat het een string word.
                    //Debug.Log("Check out this amazing joke: " + JsonObject["value"]["joke"].Value);
                    //Debug.Log("the ID of the joje is: " + JsonObject["value"]["ID"].AsInt);

                    break;
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetRequest("https://xapi.us/v2/2535439706856428/gamercard"));
        //StartCoroutine(GetGameId("https://xapi.us/v2/2535439706856428/xboxonegames"));
    }

    public string GetGamerTag()
    {
        return gamerTag;
    }
}
