using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [SerializeField] private float timeCharge;
    [SerializeField] private GameObject bullet;

    private new Rigidbody rigidbody;
    bool isShoot = true;
    bool isAlive = true;

    Inventary inventary;

    private void Start()
    {
        inventary = new Inventary();
        rigidbody = GetComponent<Rigidbody>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAlive)
        {
            if (collision.gameObject.tag == "bullet")
            {
                int dmg = collision.gameObject.GetComponent<Bullet>().Damage;
                int force = collision.gameObject.GetComponent<Bullet>().Force;
                health -= dmg;
                rigidbody.AddForce(new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.y) * force);
                if (health <= 0) { OnDestroy(); }
            }
            if (collision.gameObject.tag == "Player")
            {
                //rigidbody.AddForce(-transform.forward * speed * 2);
            }
        }       
    }

    public void Move(int s)//движение
    {
        
        rigidbody.velocity = transform.forward * s * Time.deltaTime;
    }
    public IEnumerator Shoot()
    {
        GameObject blt = Instantiate(bullet);
        blt.transform.SetParent(transform);
        blt.transform.rotation = transform.rotation;
        blt.transform.localPosition = new Vector3(0, 1f, 1);
        blt.transform.parent = null;
        isShoot = false;
        yield return new WaitForSeconds(timeCharge);
        isShoot = true;
        StopCoroutine(Shoot());
    }

    public void OnDestroy()
    {
        if (isAlive) 
        {
            inventary.KillsZombies = 1;
            isAlive = false;
        }
        
        
        Destroy(gameObject);
    }

    public bool IsShoot
    {
        get { return isShoot; }
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
