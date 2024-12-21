using System.Collections;
using System.Collections.Generic;
using EnemyBase;
using UnityEngine;

public class State_Attack : IState
{
    private EnemyReferences enemyReferences;
    private Transform target;

    public State_Attack(EnemyReferences enemyReferences)
    {
        this.enemyReferences = enemyReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Start attacking");
        target = GameObject.FindWithTag("Player").transform;
    }

    public void OnExit()
    {
        Debug.Log("Stop attacking");
        enemyReferences.animator.SetBool("attacking", false);
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

            enemyReferences.animator.SetBool("attacking", true);
        }
    }

    public Color GizmoColor()
    {
        return Color.cyan;
    }
}
