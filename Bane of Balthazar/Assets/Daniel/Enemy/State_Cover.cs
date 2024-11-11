using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Cover : IState
{
    private EnemyReferences enemyReferences;
    private StateMachine stateMachine;

    public State_Cover(EnemyReferences enemyReferences)
    {
        this.enemyReferences = enemyReferences;
    }

    public void OnEnter()
    {
        enemyReferences.animator.SetBool("combat", true);
    }

    public void OnExit()
    {
        enemyReferences.animator.SetBool("combat", false);
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.green;
    }
}
