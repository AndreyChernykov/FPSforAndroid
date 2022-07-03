using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField]int damage;
    [SerializeField] int speed;

    [SerializeField] float obstacleRange;

    private new Rigidbody rigidbody;
    Ray ray;
    

    // Start is called before the first frame update
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
        
        
        ray = new Ray(gameObject.transform.position, transform.forward);
        int angle = Random.Range(-1, 2);
        RaycastHit hit;
        if(Physics.SphereCast(ray, 1, out hit))
        {
            
            if (hit.distance < obstacleRange)
            {
                transform.rotation *= Quaternion.Euler(0, 1, 0);
                Debug.Log(hit.collider.name);
            }
            else
            {
                rigidbody.velocity = transform.forward * speed * Time.deltaTime;
            }
            
            
            
        }

    }

    private void Rotate(int n)
    {
        

        ray = new Ray(gameObject.transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, 1, out hit))
        {
            //int angle = Random.Range(-1, 2);
            if (hit.distance < obstacleRange)
            {
                transform.rotation *= Quaternion.Euler(0, n, 0);
               
            }



        }
    }

    private void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        Destroy(gameObject);



    }
}
