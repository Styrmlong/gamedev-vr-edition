using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunting : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target = null;
    private bool hunting = false;
    private bool updating = false;
    private const float UPDATE_TIME = .5f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void StartHunting(Transform player)
    {
        if (!hunting)
        {
            target = player;
            hunting = true;
            updating = true;
            StartCoroutine(UpdateTargetLocation());
        }
    }

    public void StopHunting()
    {
        if (hunting)
        {
            updating = false;
        }
    }

    public bool IsHunting()
    {
        return hunting;
    }

    private IEnumerator UpdateTargetLocation()
    {
        while (updating)
        {
            agent.SetDestination(target.position);
            yield return new WaitForSeconds(UPDATE_TIME);
        }

        agent.ResetPath();
        target = null;
        hunting = false;

        yield return null;
    }
}
