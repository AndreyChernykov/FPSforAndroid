using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int damage;
    [SerializeField] int speed;
    [SerializeField] int speedAttack;
    [SerializeField] int turnSpeed;
    [SerializeField] float distanceObstacle;//как далеко видит враг препятствия
    [SerializeField] float distanceAttack;//с какого расстояния начинает нападать
    [SerializeField] GameObject bullet;
    private bool isAttacked = false;

    private new Rigidbody rigidbody;
    int angle = 0;
    float radiusRay = 1.5f;
    Ray ray;

    
    void Start()
    {
        MainController.actionList.Add(Behavior);
        rigidbody = GetComponent<Rigidbody>();

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {            
            int dmg = collision.gameObject.GetComponent<Bullet>().Damage;
            health -= dmg;
            if (health <= 0) { OnDestroy(); }
        }

        
    }



    void Attack()//атака
    {
        //Debug.Log("piu piu!");
        
        Move(speedAttack);
    }

    public void Behavior()
{
        ray = new Ray(gameObject.transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, radiusRay, out hit))
        {
            if (!isAttacked)
            {
                if (hit.distance < distanceObstacle)
                {
                    transform.rotation *= Quaternion.Euler(0, angle, 0);

                }
                else
                {
                    int[] arr = { -turnSpeed, turnSpeed };
                    angle = arr[Random.Range(0, arr.Length)];
                    Move(speed);
                }

                if (hit.collider.tag == "Player")
                {
                    if(hit.distance < distanceAttack)
                    {
                        isAttacked = true;
                    }

                }
            }
            else
            {
                Attack();
                if(hit.collider.tag != "Player") isAttacked = false;
            }


        }

    }

    private void Move(int s)//движение
    {
        rigidbody.velocity = transform.forward * s * Time.deltaTime;
    }

    private void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        Destroy(gameObject);
    }
}
