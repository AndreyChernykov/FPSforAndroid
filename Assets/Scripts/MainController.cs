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


