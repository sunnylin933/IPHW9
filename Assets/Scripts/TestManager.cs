using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string url = "https://jsonplaceholder.typicode.com/todos/1";
        StartCoroutine(GetJsonFromUrl(url, Receiver1));
    }

    IEnumerator GetJsonFromUrl(string url, System.Action<string> callback)
    {
        string jsonText;

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");
        
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            jsonText = www.error;
        }
        else
        {
            jsonText = www.downloadHandler.text;
        }


        www.Dispose();

        callback(jsonText);
    }

    void Receiver1(string jsonText)
    {
        JsonReceiver1 receiver = JsonUtility.FromJson<JsonReceiver1>(jsonText);

        print("UserID:" + receiver.userID);
        print("id:" + receiver.id);
        print("Title:" + receiver.userID);
    }
}
