using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatk : MonoBehaviour
{
    public Animator anim;
    public int no0fClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            no0fClicks = 0;
        }

        if(Input.GetButtonDown("Fire1"))
            {
            lastClickedTime = Time.time;
            no0fClicks++;
            if(no0fClicks == 1)
            {
                anim.SetBool("atk1", true);
            }
            no0fClicks = Mathf.Clamp(no0fClicks, 0, 2);
        }
    }

    public void return1()
    {
        if(no0fClicks >= 2)
        {
            anim.SetBool("atk2", true);
        }
        else
        {
            anim.SetBool("atk1", false);
            no0fClicks = 0;
        }
    }
    public void return2()
    {
        anim.SetBool("atk1", false);
        anim.SetBool("atk2", false);
        no0fClicks = 0;
    }

}
