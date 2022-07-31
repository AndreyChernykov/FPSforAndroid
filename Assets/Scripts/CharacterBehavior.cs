using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] private new Component camera;
    [SerializeField] GameObject handsAndGun;
    Animator animator;

    float angleVert;
    float maxAngleVert = 20;//максимальный угол поворота вверх/вниз
    private new Rigidbody rigidbody;
    Inventary inventary;
    private float speedMove = 8f;//скорость перемещения
    private float graviry = 200;//гравитация
    
    PlayerController playerController;

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        animator = handsAndGun.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        inventary = new Inventary();
        StartCoroutine(HealthRecovery());
    }


    public void Move()//ходьба
    {        
        rigidbody.AddForce(0, -graviry, 0);
        rigidbody.velocity = new Vector3(speedMove * playerController.JoystyckMoveHorizontal, 0, speedMove * playerController.JoystyckMoveVertical);
        rigidbody.velocity = transform.TransformDirection(rigidbody.velocity);

        if (rigidbody.velocity.magnitude > 0) animator.SetBool("Runing", true);
        else animator.SetBool("Runing", false);
        
    }


    public void Turn()//поворот влево/вправо
    {
        transform.rotation *= Quaternion.Euler(0, playerController.JoystickTurnHorizontal, 0);
        
    }

    public void VertVisibl()//поворот вверх/вниз
    {
        angleVert -= playerController.JoysticTurnVertical;
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
