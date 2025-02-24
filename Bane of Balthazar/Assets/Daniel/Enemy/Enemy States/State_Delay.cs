using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Delay : IState
{
    private float waitForSeconds;
    private float deadline;

    public State_Delay(float waitForSeconds)
    {
        this.waitForSeconds = waitForSeconds;
    }
    
    public void OnEnter()
    {
        deadline = Time.time + waitForSeconds;
    }

    public void OnExit()
    {
        Debug.Log("Delay OnExit");
    }

    public void Tick()
    {

    }
    
    public bool IsDone()
    {
        return Time.time >= deadline;
    }

    public Color GizmoColor()
    {
        return Color.blue;
    }
}
