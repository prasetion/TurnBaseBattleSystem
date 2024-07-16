using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class Utilites
{
    // POST REQUEST
    public static IEnumerator PostRequest(string uri, string body, System.Action<UnityWebRequest.Result, string> CallbackResult)
    {
        var uwr = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(body);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        DownloadHandler downloadHandler = new DownloadHandlerBuffer();
        uwr.downloadHandler = downloadHandler;
        uwr.SetRequestHeader("Content-Type", "application/json");
        yield return uwr.SendWebRequest();
        CallbackResult?.Invoke(uwr.result, downloadHandler.text);
    }

    // GET REQUEST
    public static IEnumerator GetRequest(string uri, System.Action<UnityWebRequest.Result, string> CallbackResult)
    {
        var uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        CallbackResult?.Invoke(uwr.result, uwr.downloadHandler.text);
    }

    // random shuffle
    public static void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
