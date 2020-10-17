using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public float speed = 3;
    public float jumpPower = 8;

    float vx = 0;
    bool leftFaced = false;
    bool pushFlag = false;
    bool jumpFlag = false;
    bool touchLeg = false;
    bool isJumping = false;
    //bool canAirJump = false;
    //bool doAirJump = false;

    Animator animator;
    //SpriteRenderer spriteRenderer;
    Rigidbody2D rbody;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();

        //衝突時に回転をさせない
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;

        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFaced = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFaced = true;
        }
        if (Input.GetKey("space") && touchLeg){
            if (!pushFlag)
            {
                jumpFlag = true;
                pushFlag = true;
            }
            else{
                pushFlag = false;
            }
        }
        /*
        if(Input.GetKey("space") && canAirJump)
        {
            doAirJump = true;
        }
        */

        UpdateAnimation();

    }

    private void FixedUpdate()
    {
        //移動する
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        //向きを変える
        this.GetComponent<SpriteRenderer>().flipX = leftFaced;

        if (jumpFlag)
        {
            Debug.Log("jump");
            jumpFlag = false;
            //上方向に力を加える
            rbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        /*
        if (doAirJump)
        {
            Debug.Log("second jump");
            jumpFlag = false;
            doAirJump = false;
            canAirJump = false;
            //上方向に力を加える
            rbody.AddForce(new Vector2(0, jumpPower+1), ForceMode2D.Impulse);
        }
        */
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isJumping = false;
        touchLeg = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //canAirJump = true;
        isJumping = true;
        touchLeg = false;
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("Speed", Mathf.Abs(vx));
        animator.SetBool("Jump", isJumping);
    }
}
