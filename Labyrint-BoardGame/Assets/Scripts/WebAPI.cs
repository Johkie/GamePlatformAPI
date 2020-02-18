using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WebAPI : MonoBehaviour
{
    readonly string  webApiUrl = "https://localhost:44344/api/todoitems";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string url)
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
                HSItemAPI hsItems = JsonUtility.FromJson<HSItemAPI>(json);
                new List<HSItem>(hsItems.items).ForEach(i => Debug.Log(i.User + " | " + i.Score));
            }
        }
    }

}

public class HSItem
{
    public int Id { get; set; }
    public string User { get; set; }
    public int Score { get; set; }
}

public class HSItemAPI
{
    public HSItem[] items;
}
