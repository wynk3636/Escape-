using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFloor : MonoBehaviour
{

    public int maxCount = 50;
    int count = 0;

    public float speed = 1;
    Rigidbody2D rbody;

    public int maxRange = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;

        maxCount = Random.Range(1, maxRange);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //水平移動
        this.transform.Translate(speed / 50, 0, 0);
        rbody.velocity = new Vector2(speed, 0);
    }
    private void FixedUpdate()
    {

        count++;

        //カウントがMAX値と同じになったら向きを逆にする
        if (count == maxCount)
        {
            count = 0;
            speed = -speed;
            this.GetComponent<SpriteRenderer>().flipX = (speed < 0);
            maxCount = Random.Range(1, 100);
        }
    }

    //壁に衝突したら向きを逆にする
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            speed = -speed;
            this.GetComponent<SpriteRenderer>().flipX = (speed < 0);
        }
    }
}
