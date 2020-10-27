using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class showRanking : MonoBehaviour
{

    private string ranking = "now loading...";
    private string score = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData("https://bgqfvkyni8.execute-api.ap-northeast-1.amazonaws.com/default/escapeScoreGet"));
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = ranking;
        GameObject.Find("scoreText").GetComponent<Text>().text = score;
    }

    IEnumerator GetData(string url)
    {

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log("get ranking err");
            ranking = "sorry... \r\n err occur";
        }
        else
        {
            string response = request.downloadHandler.text;
            //Item resJson = JsonUtility.FromJson<Item>(response); //配列は対応できない

            Debug.Log(response);

            Item[] items = JsonHelper.FromJson<Item>(response);

            ranking = "";
            for(int i=0;i<items.Length; i++)
            {
                ranking = ranking + (i+1) + ": " + items[i].name + "\r\n";
                score = score + items[i].score + "\r\n";
            }
        }

    }
}

[Serializable]
public class Item
{
    public int score;
    public string name;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }


    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
