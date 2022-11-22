using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hp;

    void Awake()
    {

    }
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Hp = Hp - damage;
    }
}
