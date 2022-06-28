using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    float angleVert;
    float maxAngleVert = 20;//максимальный угол поворота вверх/вниз
   


    private new Rigidbody rigidbody;
    [SerializeField] private new Component camera;
    [SerializeField] private FixedJoystick joystick;
    private float speedMove = 7;//скорость перемещения
    
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();


    }


    public void Move()//ходьба
    {       
        rigidbody.AddForce(gameObject.transform.forward * speedMove);
        
    }

    public void Turn()//поворот влево/вправо
    {
        transform.rotation *= Quaternion.Euler(0, joystick.Horizontal, 0);

    }

    public void VertVisibl()//поворот вверх/вниз
    {
        angleVert -= joystick.Vertical;
        angleVert = Mathf.Clamp(angleVert, -maxAngleVert, maxAngleVert);

        camera.transform.localEulerAngles = new Vector3 (angleVert, 0, 0);
    }


}
