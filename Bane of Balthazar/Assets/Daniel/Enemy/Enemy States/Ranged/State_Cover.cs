using EnemyBase;
using System;
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
        stateMachine = new StateMachine();

        // States
        var enemyShoot = new State_Shoot(enemyReferences);
        var enemyDelay = new State_Delay(1f);
        var enemyReload = new State_Reload(enemyReferences);

        // Transitions
        At(enemyShoot, enemyReload, () => enemyReferences.shooter.ShouldReload());
        At(enemyReload, enemyDelay, () => !enemyReferences.shooter.ShouldReload());
        At(enemyDelay, enemyShoot, () => enemyDelay.IsDone());

        // Staart
        stateMachine.SetState(enemyShoot);

        // Functions and Conditions
        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
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
        stateMachine.Tick();
    }

    public Color GizmoColor()
    {
        return Color.green;
    }
}
