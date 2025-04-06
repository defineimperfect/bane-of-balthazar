using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<EnemyNavigation>() != null)
        {
            hit.GetComponent<EnemyNavigation>().playerDetected = true;
        }
    }
}