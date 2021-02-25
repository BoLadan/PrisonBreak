using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{

    IEnumerator GetRequest(string url)
    {
        // this pauses the webrequest untill the request returns
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
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
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    //'.Value' zorgt ervoor dat het een string word.
                    Debug.Log("Check out this amazing joke: " + JsonObject["value"]["joke"].Value);
                    Debug.Log("the ID of the joje is: " + JsonObject["value"]["ID"].AsInt);

                    break;
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetRequest("url"));
    }
}
