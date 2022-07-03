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
    [SerializeField] int turnSpeed;
    [SerializeField] float obstacleRange;//как далеко видит враг

    private new Rigidbody rigidbody;
    int angle = 0;
    float radiusRay = 1;
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

    public void Behavior()
    {
        Turn();
        

    }

    void Attack()//атака
    {
        Debug.Log("piu piu!");
    }

    private void Turn()//повороты
    {
        ray = new Ray(gameObject.transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, radiusRay, out hit))
        {

            if (hit.distance < obstacleRange)
            {
                if (hit.collider.tag == "Player") 
                {
                    Attack();
                    Move();
                } 
                else transform.rotation *= Quaternion.Euler(0, angle, 0);
                Debug.Log(hit.collider.name);
            }
            else
            {
                int[] arr = { -turnSpeed, turnSpeed };
                angle = arr[Random.Range(0, arr.Length)];
                Move();
            }

        }
    }

    private void Move()//движение
    {
        rigidbody.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        Destroy(gameObject);
    }
}
