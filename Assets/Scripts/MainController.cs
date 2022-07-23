﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MainController : MonoBehaviour
{
    
    private GameObject character;
    private new Rigidbody rigidbody;
    //private event Action action;
    public static List<Action> actionList = new List<Action>();//лист с событиями
    Inventary inventary;

    void Start()
    {
        character = GameObject.Find("Character");
        inventary = new Inventary();
        rigidbody = character.GetComponent<Rigidbody>();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()//время до конца игры
    {
        while (inventary.Time > 0)
        {
            inventary.Time--;
            yield return new WaitForSeconds(1);
        }
        StopCoroutine(Timer());
    }

    void FixedUpdate()
    {
        //if (action != null) action.Invoke();
        ActionRead();


    }

    void ActionRead()
    {
        foreach (var action in actionList)
        {            
            if(action != null) action.Invoke();
        } 
        
        
    }

    
}


