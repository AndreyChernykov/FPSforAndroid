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
    
    [SerializeField] private float timeRecovery;//время восстановления единицы здоровья
    Inventary inventary;
    private float speedMove = 7;//скорость перемещения
    
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        inventary = new Inventary();
        StartCoroutine(HealthRecovery());
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

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "enemy") Fault();
    }

    public void Fault()//сделать чтобы повреждение могло быть не на единицу а разное
    {
        rigidbody.AddForce(-transform.forward * 200);
        rigidbody.AddForce(transform.up * 200);
        
        inventary.HealthFault();
    }


    IEnumerator HealthRecovery()//авто восстановление здоровья
    {
        while (true)
        {
            inventary.HealthRecovery();
            yield return new WaitForSeconds(timeRecovery);
        }
    }
}
