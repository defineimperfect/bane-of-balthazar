using System.Collections;
using System.Collections.Generic;
using EnemyBase;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyNavigation : MonoBehaviour
{
   [Header("General")]
   [HideInInspector] public NavMeshAgent agent;
   
   [HideInInspector] public EnemyReferences enemyReferences;

    private float pathUpdateDeadline;

    public static EnemyNavigation enemyAI;

    [Header("Enemy Navigator")]
    public Transform player;

    public Transform currentDestination;

    public bool playerDetected;

    public float distanceToFollow;

    public float attackDistance;

    private float currentSpeed;
  

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
        agent = GetComponent<NavMeshAgent>();
        enemyAI = this;
    }

        // Start is called before the first frame update
        void Start()
    {
        attackDistance = agent.stoppingDistance;
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
            if(distanceToPlayer <= attackDistance)
            {
                agent.speed = 0.05f;
            }
            else
            {
                agent.speed = currentSpeed;
            }
            agent.SetDestination(player.transform.position);
            LookAtTarget();
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }
}
