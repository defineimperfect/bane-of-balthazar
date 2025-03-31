using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// IN PROGRESS!! WILL REPLACE THE NAVMESH IN "EnemyReferences" TO WORK WITH PATROL (?)
public class EnemyNavigation : MonoBehaviour
{
   [HideInInspector] public NavMeshAgent agent;

    public Transform player;

    public Transform currentDestination;

    public bool playerDetected;

    private float distanceToAttack;

    private float currentSpeed;
  

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

        // Start is called before the first frame update
        void Start()
    {
        distanceToAttack = agent.stoppingDistance;
        currentSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
     if(!playerDetected)
        {
            agent.SetDestination(currentDestination.position);
            return;
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < distanceToAttack)
            {
                agent.speed = 0;
            }
            else
            {
                agent.speed = currentSpeed;
            }
            agent.SetDestination(player.transform.position);
        }
    }
}
