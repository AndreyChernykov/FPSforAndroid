using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfBehaviour : MonoBehaviour
{
    [SerializeField] float distanceObstacle;//как далеко видит враг препятствия
    [SerializeField] float distanceAttack;
    [SerializeField] float distanceFight;//дистанция ближнего боя
    [SerializeField] int speedFight;//скорость бега при атаке в ближнем бою
    
    EnemyBehavior enemyBehavior;
    bool isAttack = false;

    private void Start()
    {
        MainController.actionList.Add(Behavior);
        enemyBehavior = GetComponent<EnemyBehavior>();
    }

    void Behavior()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        if (Physics.SphereCast(ray, 1.5f, out hit))
        {

            if (!isAttack)
            {
                if (hit.distance > distanceObstacle)
                {
                    enemyBehavior.Move(enemyBehavior.Speed);
                }
                else
                {
                    gameObject.transform.Rotate(0, 180, 0);

                }
                if(hit.distance < distanceAttack)
                {
                    if(hit.collider.tag == "Player")
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
                if(hit.distance > distanceFight)
                {
                    
                    enemyBehavior.Move(enemyBehavior.Speed);
                    if(enemyBehavior.IsShoot)StartCoroutine(enemyBehavior.Shoot());
                    
                }
                else
                {
                    enemyBehavior.Move(speedFight);
                }

            }
        }

    }



    private void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        enemyBehavior.OnDestroy();
    }
}
