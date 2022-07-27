using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private new Component camera;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private FixedJoystick joystickMove;
    //[SerializeField] private float timeRecovery;//время восстановления единицы здоровья
    
    float angleVert;
    float maxAngleVert = 20;//максимальный угол поворота вверх/вниз
    private new Rigidbody rigidbody;
    Inventary inventary;
    private float speedMove = 8f;//скорость перемещения
    private float graviry = 200;//гравитация
    

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        inventary = new Inventary();
        StartCoroutine(HealthRecovery());
    }


    public void Move()//ходьба
    {
        rigidbody.AddForce(0, -graviry, 0);
        rigidbody.velocity = new Vector3(speedMove * joystickMove.Horizontal, 0, speedMove * joystickMove.Vertical);
        rigidbody.velocity = transform.TransformDirection(rigidbody.velocity);
        
        //rigidbody.AddForce(gameObject.transform.forward * speedMove * joystickMove.Vertical);
        //rigidbody.AddForce(gameObject.transform.right * speedMove * joystickMove.Horizontal);
    }


    public void Turn()//поворот влево/вправо
    {
        transform.rotation *= Quaternion.Euler(0, joystick.Horizontal, 0);

        //transform.localEulerAngles += new Vector3(0, joystick.Horizontal, 0);        
    }

    public void VertVisibl()//поворот вверх/вниз
    {
        angleVert -= joystick.Vertical;
        angleVert = Mathf.Clamp(angleVert, -maxAngleVert, maxAngleVert);

        camera.transform.localEulerAngles = new Vector3 (angleVert, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int dmg;
        if (collision.gameObject.tag == "enemy")
        {
            
            dmg = collision.gameObject.GetComponent<EnemyBehavior>().Damage;
            Fault(dmg);
        }
        if(collision.gameObject.tag == "bullet")
        {
            dmg = collision.gameObject.GetComponent<Bullet>().Damage;
            Fault(dmg);
        }
    }

    public void Fault(int d)//сделать чтобы повреждение могло быть не на единицу а разное
    {
        rigidbody.AddForce(-transform.forward * 1000);
        rigidbody.AddForce(transform.up * 1000);
        
        inventary.HealthFault(d);
    }


    IEnumerator HealthRecovery()//авто восстановление здоровья
    {
        while (true)
        {
            inventary.HealthRecovery();
            yield return new WaitForSeconds(inventary.TimeRecovery);
        }
    }
}
