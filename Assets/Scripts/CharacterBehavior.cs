using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    new Rigidbody rigidbody;
    float rotX = 0;
    [SerializeField] FixedJoystick joystick;
    private float speedMove = 7;//скорость перемещения
    
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        
        
    }

    public void Move()//ходьба
    {
        Debug.Log("to move");
        rigidbody.AddForce(gameObject.transform.forward * speedMove);
        
    }

    public void Turn()
    {
        //Debug.Log("to turn");
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) 
        {
            
            transform.rotation *= Quaternion.Euler(0, joystick.Horizontal, 0);
            
            
        }
    }
}
