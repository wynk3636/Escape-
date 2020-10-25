using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openModal : MonoBehaviour
{

    public GameObject modalObject;
    //public string modalObjectName;

    // Start is called before the first frame update
    void Start()
    {
        //modalObject = GameObject.Find(modalObjectName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on_OpenModal()
    {
        modalObject.SetActive(true);
    }
}
