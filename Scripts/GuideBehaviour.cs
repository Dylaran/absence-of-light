using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuideBehaviour : MonoBehaviour
{
    [SerializeField] GameObject exitGoal;
    [SerializeField] GameObject beginningSpawn;
    NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(exitGoal.transform.position);
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Goal")
        {
            agent.Warp(beginningSpawn.transform.position);
            agent.SetDestination(exitGoal.transform.position);
        }
    }
}
