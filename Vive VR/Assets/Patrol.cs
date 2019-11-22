using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Patrol : MonoBehaviour
{
    private NavMeshAgent agent;
    private Waypoint target = null;
    private bool patrolling = false;
    private const float MIN_DISTANCE = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        if (patrolling && target != null) 
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, target.GetPos());

            if (distanceToWaypoint < MIN_DISTANCE) 
            {
                target = target.next;

                if (target != null)
                {
                    agent.SetDestination(target.GetPos());
                }
                else 
                {
                    StopPatrolling();
                }
            }
        }
    }

    public void StartPatrolling() 
    {
        if (!patrolling) 
        {
            target = FindObjectsOfType<Waypoint>().Aggregate((point1, point2) => 
            Vector3.Distance(transform.position, point1.GetPos()) 
            < Vector3.Distance(transform.position, point2.GetPos()) ? point1 : point2);

            agent.SetDestination(target.GetPos());
            patrolling = true;
        }
    }

    public void StopPatrolling() 
    {
        if (patrolling) 
        {
            patrolling = false;
            agent.ResetPath();
            target = null;
        }
    }

    public bool IsPatrolling() 
    {
        return patrolling;
    }
}
