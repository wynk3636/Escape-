using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("sendData Score" + updateScore.score + "name " + inputName.userName);
    }
}
