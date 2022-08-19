using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed;// �ִ�ӵ� ����
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Stop Speed 
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float���Ҷ��� f�ٿ�����Ѵ�.

        }

    }


    void FixedUpdate()
    {
        // Move by Control
        float h = Input.GetAxisRaw("Horizontal"); // Ⱦ���� Ű�� ������ 
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // �̸��� �̵��Ѵ� !


        // MaxSpeed Limit
        if (rigid.velocity.x > maxSpeed)// right
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Maxspeed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);


    }
}