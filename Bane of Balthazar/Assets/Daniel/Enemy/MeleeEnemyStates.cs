using System;
using System.Collections;
using System.Collections.Generic;
using EnemyBase;
using UnityEngine;

public class MeleeEnemyStates : MonoBehaviour
{
    private EnemyReferences enemyReferences;
    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();

        stateMachine = new StateMachine();

        // States 
        var chasePlayer = new State_ChasePlayer(enemyReferences);

        var attack = new State_Attack(enemyReferences);

        var delayAfterRun = new State_Delay(2f);

       

       // Transitions
        At(chasePlayer, delayAfterRun,() => chasePlayer.HasArrivedAtDestination());
        At(delayAfterRun, attack, () => delayAfterRun.IsDone());
       

        // Functions and Conditions
        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Tick();
    }
}

