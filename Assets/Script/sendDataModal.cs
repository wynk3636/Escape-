using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class sendDataModal : MonoBehaviour
{

    public enum DeiagResult
    {
        OK,
        Cancel,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onOk()
    {
        sendData();
    }

    public void onCancel()
    {
        this.gameObject.SetActive(false);
        //Destroy(this.gameObject);
    }

    private void sendData()
    {
        Debug.Log("sendData Score" + updateScore.score + " name " + inputName.userName);
        StartCoroutine(Post("https://9hino93qc7.execute-api.ap-northeast-1.amazonaws.com/default/escapeScoreRegister"));
    }

    IEnumerator Post(string url)
    {
        //JsonUtilityでJsonを作成
        MyScore myScore = new MyScore(inputName.userName, updateScore.score);
        string json = JsonUtility.ToJson(myScore);
        Debug.Log("json "+json);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);

        //リクエストの作成
        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        //送信
        yield return request.SendWebRequest();
    }
}

public class MyScore{

    public string name;
    public int score;

    public MyScore(string _name, int _score)
    {
        this.name = _name;
        this.score = _score;
    }
}
