using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float Speed;
    float hAxis;
    float vAxis;
    bool jDown;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;
    

    void Start()
    {
       rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Dodge();
        
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Dodge");
    }

    void Move()
    {
       
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isDodge)
            moveVec = dodgeVec;
        transform.position += moveVec * Speed * Time.deltaTime;
    }

    void Dodge()
    {
        if(jDown && !isDodge)
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
    
}
