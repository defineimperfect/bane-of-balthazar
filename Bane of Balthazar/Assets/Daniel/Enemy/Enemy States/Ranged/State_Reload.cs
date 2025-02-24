using EnemyBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Reload : IState
{
    public EnemyReferences enemyReferences;

    public State_Reload(EnemyReferences enemyReferences)
    {
        this.enemyReferences = enemyReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Start reloading.");
        enemyReferences.animator.SetFloat("cover", 1);
        enemyReferences.animator.SetTrigger("reload");
    }

    public void OnExit()
    {
        Debug.Log("Stop reloading");
        enemyReferences.animator.SetFloat("cover", 0);
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.red;
    }
}
