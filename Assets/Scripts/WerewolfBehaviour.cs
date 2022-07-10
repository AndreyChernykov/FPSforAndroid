using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfBehaviour : MonoBehaviour
{
    [SerializeField] float distanceObstacle;//как далеко видит враг препятствия
    EnemyBehavior enemyBehavior;
    bool isAttack = false;
    float radiusRay = 1.5f;

    private void Start()
    {
        MainController.actionList.Add(Behavior);
        enemyBehavior = GetComponent<EnemyBehavior>();
    }

    void Behavior()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, radiusRay, out hit))
        {
            if(hit.distance > distanceObstacle)
            {
                enemyBehavior.Move(enemyBehavior.Speed);
            }
            else
            {
                gameObject.transform.Rotate(0, 180, 0);
            }
            
        }

        if (!isAttack)
        {


        }
        else
        {

        }
    }




    private void OnDestroy()
    {
        MainController.actionList.Remove(Behavior);
        enemyBehavior.OnDestroy();
    }
}
