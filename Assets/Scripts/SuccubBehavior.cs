using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccubBehavior : MonoBehaviour
{
    [SerializeField] private int speedAttack;
    [SerializeField] private int turnSpeed;
    [SerializeField] float distanceObstacle;//как далеко видит враг препятствия
    [SerializeField] float distanceAttack;//с какого расстояния начинает нападать
    [SerializeField] GameObject bullet;
    EnemyBehavior enemyBehavior;
    public bool isAttacked = false;
    int angle = 1;//угол поворота
    bool turnRight = true;
    float radiusRay = 1f;
    Ray ray;

    void Start()
    {
        MainController.actionList.Add(Behavior);
        enemyBehavior = GetComponent<EnemyBehavior>();
    }



    void Attack()//атака
    {
        

        StartCoroutine(Shoot());
        
    }

    IEnumerator Shoot()
    {
        GameObject blt = Instantiate(bullet);
        blt.transform.SetParent(transform);
        blt.transform.rotation = transform.rotation;
        blt.transform.localPosition = new Vector3(0, 1f, 1);
        blt.transform.parent = null;
        yield return new WaitForSeconds(3);
        StopCoroutine(Shoot());
    }

    public void Behavior()
    {
        ray = new Ray(transform.position, transform.forward);

        
        RaycastHit hit;
        if (Physics.SphereCast(ray, radiusRay, out hit))
        {
            
            if (!isAttacked)
            {
                transform.rotation *= Quaternion.Euler(0, angle, 0);
                
                if (hit.distance < distanceObstacle )
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

                if (hit.collider.tag == "Player")
                {
                    isAttacked = true;
                }
            }
            else
            {


                if (hit.distance < distanceAttack)
                {
                    if (hit.collider.tag == "Player")
                    {
                        Attack();

                    }
                    
                }
                else
                {
                    isAttacked = false;

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
