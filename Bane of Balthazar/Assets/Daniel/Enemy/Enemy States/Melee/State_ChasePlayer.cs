using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ChasePlayer : IState
{
    private EnemyReferences enemyReferences;
    private Transform target;
    private float pathUpdateDeadline;

    public State_ChasePlayer(EnemyReferences enemyReferences)
    {
        this.enemyReferences = enemyReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Start chasing");
        target = GameObject.FindWithTag("Player").transform;
    }

    public void OnExit()
    {
        Debug.Log("Stop chasing");
        enemyReferences.animator.SetBool("chasing", false);
        target = null;
    }

    public void Tick()
    {
        if (target != null)
        {
            Vector3 lookPos = target.position - enemyReferences.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            enemyReferences.transform.rotation = Quaternion.Slerp(enemyReferences.transform.rotation, rotation, 0.2f);

            enemyReferences.animator.SetBool("chasing", true);

            if (Time.time >= pathUpdateDeadline)
            {
                Debug.Log("Updating Path!");
                pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
                enemyReferences.navMeshAgent.SetDestination(target.position);
            }
        }
    }

    public bool HasArrivedAtDestination()
    {
        return enemyReferences.navMeshAgent.remainingDistance < 0.1f;
    }

    public Color GizmoColor()
    {
        return Color.grey;
    }
}
