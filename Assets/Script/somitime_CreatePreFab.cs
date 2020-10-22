using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somitime_CreatePreFab : MonoBehaviour
{

    public GameObject[] newPrefab;
    public float intervalSec = 1;

    // Start is called before the first frame update
    void Start()
    {
        //メソッド実行の予約
        InvokeRepeating("CreatePrefab", intervalSec, intervalSec);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreatePrefab()
    {
        //オブジェクトの範囲
        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;

        Vector3 newPos = this.transform.position;
        newPos.x += Random.Range(-area.x / 2, area.x / 2);
        newPos.y += Random.Range(-area.y / 2, area.y / 2);
        newPos.z = -5;

        //プレハブの生成
        GameObject newObject = Instantiate(newPrefab[Random.Range(0, newPrefab.Length)]) as GameObject;
        newObject.transform.position = newPos;

    }
}
