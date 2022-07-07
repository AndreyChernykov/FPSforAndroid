using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    private new Rigidbody rigidbody;
   
    private void Start()
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

    public void OnDestroy()
    {        
        Destroy(gameObject);
    }

    public int Speed
    {
        get { return speed; }
    }

    public int Damage
    {
        get { return damage; }
    }
}
