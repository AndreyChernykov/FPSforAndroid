using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50;
    int damage;
    float timeLife = 10;
    private new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MainController.actionList.Add(Move);
        Invoke("Destroy", timeLife);
    }

    

    private void Move()
    {
        //gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        rigidbody.velocity = new Vector3(0, 0, speed);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    public void Destroy()
    {
        MainController.actionList.Remove(Move);
        Destroy(gameObject);
    }
}
