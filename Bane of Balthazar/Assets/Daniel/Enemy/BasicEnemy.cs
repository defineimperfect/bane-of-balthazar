using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

// BASIC ENEMY SCRIPT, ALLOWS ENEMY TO LOOK AT PLAYER DIRECTION AND BEGINS ATTACK ANIMATION.
// FOR ATTACK SCRIPTS, SEE "EnemyMelee" OR "EnemyShooter" 
// APPLY SCRIPTS TO ENEMY ALONG WITH MENTIONED ATTACK SCRIPTS.
// IF A MORE ADVANCED ENEMY IS DESIRED, MAKE USE OF EITHER "MeleeEnemyStates" OR "RangedEnemyStates" DEPENDING ON ENEMY TYPE.
// NOTE: WILL UNDERGO CHANGES. 

namespace EnemyBase
{
    public class BasicEnemy : MonoBehaviour
    {
        [Header("Enemy")]

        public static BasicEnemy Enemy;

        public Transform target;

        public bool inRadius;
      
        private EnemyReferences enemyReferences;

        private float pathUpdateDeadline;

        private float delay = 3; 

        private float attackingDistance;
        
        private void Awake()
        {
            enemyReferences = GetComponent<EnemyReferences>();
            Enemy = this;
        }
       
        void Start()
        {
            attackingDistance = enemyReferences.navMeshAgent.stoppingDistance; // Attacking distance is the same as navMesh agent's stopping distance!
        }

        void Update()
        {
            if(target != null)
            {
                inRadius = Vector3.Distance(transform.position, target.position) <= attackingDistance; // Player is in range if distance between player and enemy is less or equal to the enemy's attacking distance!
               
                if (inRadius)
                {
                  LookAtTarget(); // If in range, call method "LookAtTarget()"
                }
                else
                {

                    Invoke("UpdatePath", delay); // If not in range, update path via method "UpdatePath()"
                }
            }
            
            enemyReferences.animator.SetBool("attacking", inRadius); // Trigger bool parameter, "attacking" in animator.
         
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
               // Debug.Log("Updating Path!");
                pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
                enemyReferences.navMeshAgent.SetDestination(target.position);
            }
        }
    }
}