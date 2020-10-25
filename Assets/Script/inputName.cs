using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputName : MonoBehaviour
{

    public static string userName;
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        userName = "";
        input = input.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void inputText()
    {
        userName = input.text;
    }
}
