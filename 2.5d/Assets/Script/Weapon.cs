using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector3 Sphere;
    void Attack()
    {
            if(curTime <= 0)
            {
                
                if (Input.GetButtonDown("Fire1"))
                {
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 0);
                    foreach (Collider item in colliders)
                    

                   curTime = coolTime;
                }
            }
            else
            {
                curTime -= Time.deltaTime;
            }


        
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, Sphere);
    }

    void Update()
    {
        Attack();
    }
}