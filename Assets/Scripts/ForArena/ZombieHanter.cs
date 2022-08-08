using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHanter : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MainController.actionList.Add(Move);
    }

    private void Move()
    {
        agent.destination = player.transform.position;
    }
}
