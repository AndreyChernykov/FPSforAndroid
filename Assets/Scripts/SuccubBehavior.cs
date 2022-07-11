using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccubBehavior : MonoBehaviour
{
    [SerializeField] private int speedAttack;
    [SerializeField] private int turnSpeed;
    [SerializeField] float distanceObstacle;//как далеко видит враг препятствия
    [SerializeField] float distanceAttack;//с какого расстояния начинает нападать
    
    EnemyBehavior enemyBehavior;
    public bool isAttack = false;
    int angle = 1;//угол поворота
    bool turnRight = true;
    Ray ray;

    void Start()
    {
        MainController.actionList.Add(Behavior);
        enemyBehavior = GetComponent<EnemyBehavior>();
    }



    void Attack()//атака
    {
        if (enemyBehavior.IsShoot) StartCoroutine(enemyBehavior.Shoot());

    }

    

    public void Behavior()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);

        ray = new Ray(transform.position, transform.forward);

        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
            if (!isAttack)
            {
                transform.rotation *= Quaternion.Euler(0, angle, 0);
                if (hit.distance < distanceObstacle)
                {
                    if (turnRight && hit.collider.tag != "bullet")
                    {
                        angle = angle < 0 ? turnSpeed : -turnSpeed;
                        turnRight = false;
                    }
                }
                else
                {
                    turnRight = true;

                }
                if (hit.distance < distanceAttack)
                {
                    if (hit.collider.tag == "Player")
                    {
                        isAttack = true;
                    }
                }
            }
            else
            {
                if (hit.distance > distanceAttack)
                {
                    if (hit.collider.tag != "Player")
                    {
                        isAttack = false;
                    }
                }
                else
                {
                    if (enemyBehavior.IsShoot) StartCoroutine(enemyBehavior.Shoot());
                }

            }
        }
    }


    void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        enemyBehavior.OnDestroy();
    }

}
