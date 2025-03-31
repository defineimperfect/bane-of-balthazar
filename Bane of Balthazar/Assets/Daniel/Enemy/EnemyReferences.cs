using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyBase
{
    [DisallowMultipleComponent]

    // NOTE: WILL UNDERGO CHANGES
    public class EnemyReferences : MonoBehaviour
    {
        public static EnemyReferences enemy;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public Animator animator;
        [HideInInspector] public EnemyShooter shooter;
        [HideInInspector] public EnemyMelee melee;

            
       
        [Header("Stats")]

        public float pathUpdateDelay = 1f;
        
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            shooter = GetComponent<EnemyShooter>();
            melee = GetComponent<EnemyMelee>();
            enemy = this;
        }
    }
}