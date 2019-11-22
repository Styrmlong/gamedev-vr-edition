using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFinder : MonoBehaviour
{
    public Transform player;
    private Hunting huntingController;
    private Patrol patrolController;
    void Start()
    {
        huntingController = GetComponent<Hunting>();
        patrolController = GetComponent<Patrol>();
    }
    public void ToggleHunting()
    {
        if (patrolController.IsPatrolling())
        {
            patrolController.StopPatrolling();
            huntingController.StartHunting(player);
        }
        else if (huntingController.IsHunting())
        {
            huntingController.StopHunting();
        }
        else
        {
            huntingController.StartHunting(player);
        }
    }

    public void TogglePatrolling()
    {
        if (huntingController.IsHunting())
        {
            huntingController.StopHunting();
            patrolController.StartPatrolling();
        }
        else if (patrolController.IsPatrolling())
        {
            patrolController.StopPatrolling();
        }
        else
        {
            patrolController.StartPatrolling();
        }
    }
    public void StopMoving()
    {
        if (huntingController.IsHunting())
        {
            huntingController.StopHunting();
        }
        else if (patrolController.IsPatrolling())
        {
            patrolController.StopPatrolling();
        }
    }
}
