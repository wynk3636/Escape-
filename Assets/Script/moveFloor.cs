using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFloor : MonoBehaviour
{

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //水平移動
        this.transform.Translate(speed / 50, 0, 0);
    }
}
