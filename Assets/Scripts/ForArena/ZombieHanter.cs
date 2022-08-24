using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHanter : MonoBehaviour
{
    static GameObject player;
    EnemyBehavior enemyBehavior;
    NavMeshAgent agent;
    void Start()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();
        player = GameObject.Find("Character");
        agent = GetComponent<NavMeshAgent>();
        MainController.actionList.Add(Move);
    }

    private void Move()
    {
        agent.destination = player.transform.position;
    }

    public void OnDestroy()
    {
        MainController.actionList.Remove(Move);
        enemyBehavior.OnDestroy();
    }
}
