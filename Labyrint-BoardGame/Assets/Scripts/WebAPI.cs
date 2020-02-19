using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public delegate void HighScoreItemDelegate(List<HSItem> items);

public class WebAPI : MonoBehaviour
{
    public HighScoreItemDelegate highScoreUpdateCallback;

    readonly string  webApiUrl = "https://localhost:44321/api/HighscoreItems";

    private List<HSItem> hsItems;

    public void UpdateHighScore()
    {
        StartCoroutine(GetHighScoreRequest(webApiUrl + "/top/5"));
    }
    public void AddHighScore(HSItem item)
    {
        StartCoroutine(PostHighScoreRequest(webApiUrl, item));
    }
    public IEnumerator GetHighScoreRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("ERROR: " + webRequest.error);
            }
            else
            {
                string json = "{\"items\":" + webRequest.downloadHandler.text + "}";
                HSItemAPI hsItemsAPI = JsonUtility.FromJson<HSItemAPI>(json);
                hsItems = new List<HSItem>((hsItemsAPI.items));
                highScoreUpdateCallback.Invoke(hsItems);
            }
        }
    }
    public IEnumerator PostHighScoreRequest(string url, HSItem item)
    {
        string json = "{\"user\":\"" + item.user + "\",\"score\":" + item.score + "}";
        byte[] jsonToByte = new System.Text.UTF8Encoding().GetBytes(json);
        
        using (UnityWebRequest webRequest = UnityWebRequest.Post(webApiUrl, "POST"))
        {
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToByte);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
           
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log("ERROR: " + webRequest.error);
            }
            else
            {
                Debug.Log("Request sent");
                UpdateHighScore();
            }
        }
    }
}
[Serializable]
public class HSItem
{
    public int id;
    public string user;
    public int score;
}
[Serializable]
public class HSItemAPI
{
    public HSItem[] items;
}
