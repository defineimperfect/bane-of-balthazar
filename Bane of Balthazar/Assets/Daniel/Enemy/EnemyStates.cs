using EnemyBase;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    private EnemyReferences enemyReferences;
    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();

        stateMachine = new StateMachine();

        FindCovers findCovers = FindObjectOfType<FindCovers>();

        // States 
        var runToCover = new State_RunToCover(enemyReferences, findCovers);

        var delayAfterRun = new State_Delay(2f);

        var cover = new State_Cover(enemyReferences);

        // Transitions
        At(runToCover, delayAfterRun, () => runToCover.HasArrivedAtDestination());
        At(delayAfterRun, cover, () => delayAfterRun.IsDone());

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
