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
    bool ADown;
    

    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;
    public SpriteRenderer theSR;
    public Animator anim;

    
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

     
    }

    private void Start()
    {
        
    }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Dodge");
        JDown = Input.GetButtonDown("Jump");

        ADown = Input.GetButtonDown("Fire1");

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
            anim.SetBool("isjump", true);
            anim.SetTrigger("jump");
        }
        

    }

    void Dodge()
    {
        if (jDown && !isDodge)
        {
            dodgeVec = moveVec;
            Speed *= 2;
            isDodge = true;
            anim.SetBool("Dash", true);

            Invoke("DodgeOut", 0.4f);

        }
        

    }

   
    void DodgeOut()
    {
        Speed *= 0.5f;
        isDodge = false;
        anim.SetBool("Dash",false);
    }

    void Attack()
    {
        if (ADown)
        {
            
            anim.SetTrigger("atk");
        }

    }


    void Sprite()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        //มกวม
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
            anim.SetBool("isjump", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "EnemyBullet")
        {
            
        }
    }




    void Update()
    {
        GetInput();
        Move();
        Dodge();
        Jump();
        Sprite();
        Attack();
        
    }
}