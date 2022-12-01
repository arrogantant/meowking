using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Combatk : MonoBehaviour
{
    public Animator anim;
    public int no0fClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay;

    public bool IsJumping;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        

    }

    private void Update()
    {
            if (Time.time - lastClickedTime > maxComboDelay)
            {
                no0fClicks = 0;
            }

            if (Input.GetButtonDown("Fire1") )
            {
                lastClickedTime = Time.time;
                no0fClicks++;
                if (no0fClicks == 1)
                {
                    anim.SetBool("atk1", true);
                anim.SetBool("jatk1", false);
                anim.SetBool("jatk2", false);
                //공격할때 속도감소
                PlayerMove call = GameObject.Find("Player").GetComponent<PlayerMove>();
                    call.Speed = 0f;
                Debug.Log("slow");


            }
                no0fClicks = Mathf.Clamp(no0fClicks, 0, 5);


            }



    }

    public void return1()
    {

        if (no0fClicks >= 2)
        {
            anim.SetBool("atk2", true);
            anim.SetBool("jatk1", false);
            anim.SetBool("jatk2", false);
        }
        else
        {
            anim.SetBool("atk1", false);
            anim.SetBool("jatk1", false);
            anim.SetBool("jatk2", false);
            //공격할때 속도감소
            no0fClicks = 0;
            PlayerMove call = GameObject.Find("Player").GetComponent<PlayerMove>();
            call.Speed = 6;
        Debug.Log("1 fast");
        }
    }
    public void return2()
    {

        anim.SetBool("atk1", false);
        anim.SetBool("atk2", false);
        anim.SetBool("jatk1", false);
        anim.SetBool("jatk2", false);
        no0fClicks = 0;
        PlayerMove call = GameObject.Find("Player").GetComponent<PlayerMove>();
        call.Speed = 6;
        Debug.Log("2 fast");
    }

    public void return3()
    {

        if (no0fClicks >= 2)
        {
            anim.SetBool("atk1", false);
            anim.SetBool("atk2", false);
            anim.SetBool("jatk2", true);
        }
        else
        {
            anim.SetBool("atk1", false);
            anim.SetBool("atk2", false);
            anim.SetBool("jatk1", false);
            //공격할때 속도감소
            no0fClicks = 0;
            PlayerMove call = GameObject.Find("Player").GetComponent<PlayerMove>();
            call.Speed = 6;
            Debug.Log("3 fast");
        }
    }

    public void return4()
    {

        anim.SetBool("atk1", false);
        anim.SetBool("atk2", false);
        anim.SetBool("jatk1", false);
        anim.SetBool("jatk2", false);
        no0fClicks = 0;
        PlayerMove call = GameObject.Find("Player").GetComponent<PlayerMove>();
        call.Speed = 6;
        Debug.Log("4 fast");
    }
}



