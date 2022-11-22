using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatk : MonoBehaviour
{
    public Animator anim;
    public int no0fClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.9f;

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
                anim.SetBool("atk 1", true);
            }
            no0fClicks = Mathf.Clamp(no0fClicks, 0, 3);
        }
    }
}
