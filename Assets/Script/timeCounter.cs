using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCounter : MonoBehaviour
{

    public static int time = 0;
    public int _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = _time;
        InvokeRepeating("ReduceTime", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = time.ToString();
    }

    private void ReduceTime()
    {
        if (time > 0)
        {
            time--;
        }

        if(time==0)
        {
            //Debug.Log("gameover by count");
            gameStateManager.gameState = false;
        }
    }
}
