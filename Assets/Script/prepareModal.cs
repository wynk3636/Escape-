using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prepareModal : MonoBehaviour
{
    public GameObject modalObject;
    public string modalObjectName;

    // Start is called before the first frame update
    void Start()
    {
        modalObject = GameObject.Find(modalObjectName);
        modalObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
