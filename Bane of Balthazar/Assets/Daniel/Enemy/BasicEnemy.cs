using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyBase
{
    public class BasicEnemy : MonoBehaviour
    {
        [Header("Enemy")]

        public Transform target;

        private EnemyReferences enemyReferences;

        private float pathUpdateDeadline;

        private float attackingDistance;

        private void Awake()
        {
            enemyReferences = GetComponent<EnemyReferences>();
        }
       
        void Start()
        {
            attackingDistance = enemyReferences.navMeshAgent.stoppingDistance;
        }

        void Update()
        {
            if(target != null)
            {
                bool inRange = Vector3.Distance(transform.position, target.position) <= attackingDistance;

                if(inRange)
                {
                    LookAtTarget();
                }
                else
                {
                    UpdatePath();
                }
            
            enemyReferences.animator.SetBool("attacking", inRange);
            }
            enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
        }

        private void LookAtTarget()
        {
            Vector3 lookPos = target.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        }

        private void UpdatePath()
        {
            if(Time.time >= pathUpdateDeadline)
            {
                Debug.Log("Updating Path!");
                pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
                enemyReferences.navMeshAgent.SetDestination(target.position);
            }
        }
    }
}