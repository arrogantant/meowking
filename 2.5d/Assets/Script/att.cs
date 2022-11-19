using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class att : MonoBehaviour
{

    public Animator anim;
    private void Start()
    {
        
    }

    public void PlayAnimation(int atkNum)
    {
        anim.SetFloat("Blend", atkNum);
        anim.SetTrigger("atk");
    }

    public Slider slider;
    public int speed;
    public float minPos;
    public float maxPos;
    public RectTransform pass;
    public int atkNum;
    public void SetAtk()
    {
        slider.value = 0;
        minPos = pass.anchoredPosition.x;
        maxPos = pass.sizeDelta.x + minPos;
        StartCoroutine(ComboAtk());
    }
    IEnumerator ComboAtk()
    {
        yield return null;
        while(!(Input.GetButtonDown("Fire1") ||slider.value == slider.maxValue))
                {
            slider.value += Time.deltaTime * speed;
            yield return null;
        }
        if(slider.value >= minPos&&slider.value <= maxPos)
        {
            PlayAnimation(atkNum++);
            if (atkNum < 1)
                SetAtk();
            else
            {
                atkNum = 0;
                isAtk = false;
            }
        }
        else
        {
            PlayAnimation(0);
            isAtk = false;
            atkNum = 0;
        }
        slider.value = 0;
    }
    bool isAtk = false;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1")&&!isAtk)
                {
            isAtk = true;
            SetAtk();
        }
    }
}
