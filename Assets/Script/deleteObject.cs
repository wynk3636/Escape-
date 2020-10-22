using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{

    public float limitSec = 3;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト削除の予約
        Destroy(this.gameObject, limitSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Hell")
        {
            //削除
            this.gameObject.SetActive(false);
        }
    }
}
