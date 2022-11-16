using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float JumpPower;
    public float Speed;
    float hAxis;
    float vAxis;
    bool jDown;
    bool isDodge;
    bool isJump;
    bool JDown;
    

    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;
    public SpriteRenderer theSR;
    public Animator anim;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Dodge");
        JDown = Input.GetButtonDown("Jump");

    }

    void Move()
    {

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        anim.SetBool("run", moveVec != Vector3.zero);
        

        if (isDodge)

        moveVec = dodgeVec;
        transform.position += moveVec * Speed * Time.deltaTime;


    }

    void Jump()
    {
        if (JDown && !isJump)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isJump = true;


        }

    }

    void Dodge()
    {
        if (jDown && !isDodge)
        {
            dodgeVec = moveVec;
            Speed *= 2;
            isDodge = true;

            Invoke("DodgeOut", 0.4f);
        }
    }

   
    void DodgeOut()
    {
        Speed *= 0.5f;
        isDodge = false;
    }

    void Sprite()
    {
        if (!theSR.flipX && hAxis < 0)
        {
            theSR.flipX = true;
        }

        else if (theSR.flipX && hAxis > 0)
        {
            theSR.flipX = false;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
            
        }
    }


    void Update()
    {
        GetInput();
        Move();
        Dodge();
        Jump();
        Sprite();


    }
}