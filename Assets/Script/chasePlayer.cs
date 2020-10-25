using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{

    public string targetObjectName;
    public float speed = 1;

    GameObject targetObject;
    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find(targetObjectName);

        //回転抑止
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 targetDirect = (targetObject.transform.position - this.transform.position).normalized;

        //進む量
        float vx = targetDirect.x * speed;
        float vy = targetDirect.y * speed;
        rbody.velocity = new Vector2(vx, vy);

        //移動方向で左右に向きを変える
        this.GetComponent<SpriteRenderer>().flipX = (vx > 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameStateManager.gameState = false;
        }
    }
}
