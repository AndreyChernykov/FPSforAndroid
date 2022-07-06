using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int health = 10;
    private new Rigidbody rigidbody;

    
    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {            
            int dmg = collision.gameObject.GetComponent<Bullet>().Damage;
            health -= dmg;
            if (health <= 0) { OnDestroy(); }
        }

        
    }

    public void Move(int s)//движение
    {
        rigidbody.velocity = transform.forward * s * Time.deltaTime;
    }

    protected void OnDestroy()
    {        
        Destroy(gameObject);
    }
}
