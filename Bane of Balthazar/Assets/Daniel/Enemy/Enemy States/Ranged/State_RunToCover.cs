using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_RunToCover : IState
{
    private EnemyReferences enemyReferences;
    private FindCovers findCovers;

    public State_RunToCover(EnemyReferences enemyReferences, FindCovers findCovers)
    {
        this.enemyReferences = enemyReferences;
        this.findCovers = findCovers;
    }

    public void OnEnter()
    {
        Cover nextCover = this.findCovers.GetRandomCover(enemyReferences.transform.position);
        enemyReferences.navMeshAgent.SetDestination(nextCover.transform.position);
    }

    public void OnExit()
    {
        enemyReferences.animator.SetFloat("speed", 0f);
    }

    public void Tick()
    {
        enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
    }

    public bool HasArrivedAtDestination()
    {
        return enemyReferences.navMeshAgent.remainingDistance < 0.1f;
    }
    public Color GizmoColor()
    {
        return Color.red;
    }
}
