﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    float speed = 100;
    int damage;
    float lifeTime = 1;
    private new Rigidbody rigidbody;
    private float scattX = 0, scattY = 0;
    private float angleScatt = 20;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MainController.actionList.Add(Move);
        scattX = Scatter();
        scattY = Scatter();

        Invoke("Destroy", lifeTime);
        
    }

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
        Destroy();
    }

    public void Destroy()
    {
        MainController.actionList.Remove(Move);
        Destroy(gameObject);
    }
}
