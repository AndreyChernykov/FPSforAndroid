using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : EnemyBehavior
{
    
    [SerializeField] private int damage;
    [SerializeField] public int speed;
    [SerializeField] private int speedAttack;
    [SerializeField] private int turnSpeed;
    [SerializeField] float distanceObstacle;//как далеко видит враг препятствия
    [SerializeField] float distanceAttack;//с какого расстояния начинает нападать
    
    private bool isAttacked = false;
    int angle = 0;
    float radiusRay = 1.5f;
    Ray ray;

    new void Start()
    {
        base.Start();
        MainController.actionList.Add(Behavior);
    }

    void Attack()//атака
    {
        //Debug.Log("piu piu!");
        
        base.Move(speedAttack);
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
                    base.Move(speedAttack);
                }

                if (hit.collider.tag == "Player")
                {
                    if (hit.distance < distanceAttack)
                    {
                        isAttacked = true;
                    }

                }
            }
            else
            {
                Attack();
                if (hit.collider.tag != "Player") isAttacked = false;
            }


        }

    }

    private new void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        base.OnDestroy();
    }

}
