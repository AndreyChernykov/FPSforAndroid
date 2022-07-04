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
    [SerializeField] private int health;
    [SerializeField] private float timeRecovery;//время восстановления единицы здоровья
    private int maxHealth;
    private float speedMove = 7;//скорость перемещения
    
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        maxHealth = health;

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
        if (health >= 0)
        {
            health--;           
        }
    }

   private void Recovery()//сделать чтоб здоровье восстанавливалось автоматически за опрделённое время
    {
        
        
    }

    IEnumerator HealthRecovery()
    {
        while (true)
        {
            if (health > 0 && health < maxHealth)
            {
                
                health++;

            }
            yield return new WaitForSeconds(timeRecovery);
        }
        

    }
}
