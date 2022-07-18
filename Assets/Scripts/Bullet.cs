using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] int amountBullets;//количество выпущеных пуль (для дроби)
    [SerializeField] int force;//сила с которой отбрасывает врага
    [SerializeField] int damage;
    [SerializeField] private float angleScatt;//угол разлёта
    float speed = 40;   
    float lifeTime = 1;
    private new Rigidbody rigidbody;
    private float scattX = 0, scattY = 0;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MainController.actionList.Add(Move);
        scattX = Scatter();
        scattY = Scatter();

        Invoke("Destroy", lifeTime);
       
    }
    public int AmountBullets { get { return amountBullets; } }

    public int Force { get { return force; } }

    public int Damage { get { return damage; } }

private float Scatter()//разлёт для дроби
    {
        return UnityEngine.Random.Range(-angleScatt, angleScatt);
    }

    private void Move()
    {
       
        transform.Translate(scattX * Time.deltaTime, scattY * Time.deltaTime, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag != gameObject.tag) Destroy();
    }

    public void Destroy()
    {
        MainController.actionList.Remove(Move);
        Destroy(gameObject);
    }
}
