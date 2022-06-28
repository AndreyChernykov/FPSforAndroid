using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainController : MonoBehaviour
{
    //private event Action action;
    public static List<Action> actionList = new List<Action>();//лист с событиями
    
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (action != null) action.Invoke();
        ActionRead();
    }

    void ActionRead()
    {
        foreach(var action in actionList) action.Invoke();
        
        //actionList.Clear();
    }
}
