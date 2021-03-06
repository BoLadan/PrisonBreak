using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{
    public static APIConnection instance { get; private set; }

    private string authKey = "323ccac15d8c7ab9ce00f9e69320d48015d2eb89";
    private string gamerTag;
    private string gameName;
    private string gameId;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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

                    //Debug.Log("Test: " + JsonObject["titles"][0]["name"]);

                    gameName = JsonObject["titles"][0]["name"];
                    gameId = JsonObject["titles"][0]["titleId"];
                    Debug.Log("the name of the game you seek is: " + gameName + " and its ID is: " + gameId);

                    break;
            }
        }
    }

    IEnumerator GetAchivement(string url)
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


                    for (int i = 0; i < JsonObject.Count; i++)
                    {
                        if (JsonObject[i]["name"].Value == "Become Pirate Legend")
                        {
                            Debug.Log("je bent Priate Legend!!!!");
                        }
                    }

                    break;
            }
        }
    }

    void Start()
    {
        //StartCoroutine(GetRequest("https://xapi.us/v2/2535439706856428/gamercard"));
        //StartCoroutine(GetGameId("https://xapi.us/v2/2535439706856428/xboxonegames"));
        StartCoroutine(GetAchivement("https://xapi.us/v2/2535439706856428/achievements/1717113201"));
    }

    public string GetAuthKey()
    {
        return authKey;
    }

    public string GetGamerTag()
    {
        return gamerTag;
    }

    public string GetGameName()
    {
        return gameName;
    }

    public string GetGameId()
    {
        return gameId;
    }


}
