﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class movePlayer : MonoBehaviour
{

    public float speed = 3;
    public float jumpPower = 8;

    float vx;
    bool leftFaced;
    bool pushFlag;
    bool jumpFlag;
    bool touchLeg;
    bool isJumping;
    //bool canAirJump = false;
    //bool doAirJump = false;

    Animator animator;
    //SpriteRenderer spriteRenderer;
    Rigidbody2D rbody;


    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        leftFaced = false;
        pushFlag = false;
        jumpFlag = false;
        touchLeg = false;
        isJumping = false;

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

        //GetButtonで長押し対応 GetButtonDownで押した時
        if (Input.GetKey("right") || CrossPlatformInputManager.GetButton("right") || CrossPlatformInputManager.GetButtonDown("right"))
        {
            vx = speed;
            leftFaced = false;
        }
        if (Input.GetKey("left") || CrossPlatformInputManager.GetButton("left") || CrossPlatformInputManager.GetButtonDown("left"))
        {
            vx = -speed;
            leftFaced = true;
        }
        if ((Input.GetKey("space") || CrossPlatformInputManager.GetButton("Jump") || CrossPlatformInputManager.GetButtonDown("Jump")) && touchLeg){
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
            //Debug.Log("jump");
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



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            transform.SetParent(col.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            transform.SetParent(null);
        }
    }
}
